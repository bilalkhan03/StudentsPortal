using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task   <IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Subscribed = viewModel.Subscribed,
                };
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("List", "Students");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var Students = await dbContext.Students.ToListAsync();
            return View(Students);
                
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
           var student =  await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {
            var student = await dbContext.Students.FindAsync(viewmodel.Id);

            if (student is not null)
            {
                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.Phone = viewmodel.Phone;
                student.Subscribed = viewmodel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Student viewmodel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == viewmodel.Id );
            if (student is not null)
            {
                dbContext.Students.Remove(viewmodel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
      

    }
}
