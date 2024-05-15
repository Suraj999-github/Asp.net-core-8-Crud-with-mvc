using CRUD.DbContexts;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/student/list")]
        public IActionResult list()
        {
            return View();
        }
        [HttpPost]
        [Route("/student/list")]
        public async Task<Object> listStudent()
        {
            try
            {
              return await _context.student.ToListAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet]
        [Route("/student/add")]
        public IActionResult add()
        {
            AddStudent student = new AddStudent();
            return View(student);
        }
        [HttpPost]
        [Route("/student/add")]
        public async Task<IActionResult> add(AddStudent req)
        {
            try
            {
                Student entity = new Student();
                entity.PhoneNumber = req.PhoneNumber;
                entity.FirstName = req.FirstName;
                entity.LastName = req.LastName;
                entity.MiddleName = req.MiddleName;
                entity.Salutation = req.Salutation;
                entity.CreatedDate= DateTime.Now;
                await _context.student.AddAsync(entity);
                await _context.SaveChangesAsync();            
                return Redirect("/student/list");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return View(req);
            }
        }

        [HttpGet]
        [Route("/student/update/{id}")]
        public async Task<IActionResult> update(long id)
        {
            var data= await _context.student.FindAsync(id);
            UpdateStudent student = new UpdateStudent();
            student.Id = data.Id;
            student.PhoneNumber = data.PhoneNumber;
            student.FirstName = data.FirstName;
            student.LastName = data.LastName;
            student.MiddleName = data.MiddleName;
            student.Salutation = data.Salutation;
            return View(student);
        }
        [HttpPost]
        [Route("/student/update/{id}")]
        public async Task<IActionResult> update(UpdateStudent req, long id)
        {
            try
            {
                Student entity = new Student();
                entity = await _context.student.FindAsync(req.Id);
                if (entity != null)
                {
                    entity.PhoneNumber = req.PhoneNumber;
                    entity.FirstName = req.FirstName;
                    entity.LastName = req.LastName;
                    entity.MiddleName = req.MiddleName;
                    entity.Salutation = req.Salutation;
                    _context.student.Update(entity);
                    await _context.SaveChangesAsync();
                }
                return Redirect("/student/list");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return View(req);
            }
        }

    }
}
