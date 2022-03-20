using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThucHanh1402.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BaiThucHanh1402.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        ExcelProcess _excelPro = new ExcelProcess ();
        
        ToUpperCase ToUC = new ToUpperCase();
        AutoGenerateKey Aukey = new AutoGenerateKey();

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IConfiguration Configuration {get;}
        private int WriteDatatableToDatabase(DataTable dt)
        {
            try
            {
            var con = Configuration.GetConnectionString("ApplicationDBContext");
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.DestinationTableName = "Employees";
            bulkCopy.ColumnMappings.Add(1, "EmployeeID");
            bulkCopy.ColumnMappings.Add(2, "EmployeeName");
            bulkCopy.ColumnMappings.Add(3, "Address");
            bulkCopy.WriteToServer(dt);
            }
            catch
            {
                return 0;
            }
            return dt.Rows.Count;
        }       


        // GET: Employees
            public async Task<IActionResult> Index(string searchString)
            {
                var movies = from m in _context.Employee
                             select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    movies = movies.Where(s => s.EmployeeName.Contains(searchString));
                }

                return View(await movies.ToListAsync());
            }
        

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            string NewID = "";
            var emp = _context.Employee.ToList().OrderByDescending(c => c.EmployeeID); // lay danh sach person theo ID lon nhat
            var countEmployee = _context.Employee.Count();

            if (countEmployee == 0)
            {
                NewID = "NV001";
            }
            else
            {
                NewID = Aukey.GenerateKey(emp.FirstOrDefault().EmployeeID);
            }
            ViewBag.EmpID = NewID;
            return View();
        }

        // excel
        public IActionResult Excel()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Excel(Employee emp,IFormFile file){
            
             if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    //tao duong dan /Uploads/Excels de luu file upload len server
                    var fileName = "NetCore";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                    var fileLocation = new FileInfo(filePath).ToString();
                    if (ModelState.IsValid)
                    {
                        //upload file to server
                        if (file.Length > 0)
                        {
                            _context.Add(emp);
                            await _context.SaveChangesAsync();
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                //_excelPro la doi tuong xu ly file excel ExcelProcess
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                //ghi du lieu datatable vao database                            
                                // if (emp.CategoryID==0)
                                if (true)
                                {
                                    WriteDatatableToDatabase (dt);
                                }
                                else
                                {
                                    WriteDatatableToDatabase (dt);
                                }
                            }
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            return View(emp);
        }
        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,Address")] Employee employee)
        {
            employee.EmployeeName = ToUC.upperCase(employee.EmployeeName);
            employee.Address = ToUC.upperCase(employee.Address);

            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,EmployeeName")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}
