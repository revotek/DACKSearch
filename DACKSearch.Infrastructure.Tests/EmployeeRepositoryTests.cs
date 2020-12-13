using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DACKSearch.Infrastructure.Tests
{
    public class EmployeeRepositoryTests
    {
        [Fact]
        public async Task get_employee_data()
        {
            var options = new DbContextOptionsBuilder<DackDbContext>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}