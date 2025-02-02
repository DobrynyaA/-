using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace NikePro.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeServices(ApplicationDbContext context) { _context = context; }

        public async Task AddEmployee(ApplicationUser user)
        {
            try
            {
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Employee");

                var passwordHasher = new PasswordHasher<ApplicationUser>();

                user.PasswordHash = passwordHasher.HashPassword(user, "t2f4t5qQ!");

                var res = await _context.Users.AddAsync(user);

                await _context.UserRoles.AddAsync(
                new IdentityUserRole<string>
                {
                    RoleId = role.Id,
                    UserId = user.Id
                }
                );

                var employee = new Employee
                {
                    UserId = user.Id,
                };
                await _context.Employees.AddAsync(employee);

                await _context.SaveChangesAsync();
                Console.WriteLine("Создал сотрудника");
            }
            catch
            {
                Console.WriteLine("Не удалось создать сотрудника");
            }

        }


        public async Task DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            var user = await _context.Users.FirstOrDefaultAsync(e=>e.Id == employee.UserId);
            _context.Users.Remove(user);
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(e=>e.UserId == employee.UserId);
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task EditEmployee(Employee employee)
        {
            _context.Attach(employee!).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency error occurred: {ex.Message}");
                throw;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database update error occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.Include(e=>e.User).ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include(e => e.User).FirstOrDefaultAsync(e=>e.EmployeeId == id);
        }
    }
}
