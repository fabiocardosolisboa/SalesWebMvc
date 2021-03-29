using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        public SeedingService(SalesWebMvcContext context) 
        {
            _context = context;
        }
        public void Seed() 
        {
            if(_context.Department.Any()||_context.Seller.Any()||_context.SalesRecord.Any())
            {
                return;
            }
            //Departamentos
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");
            //Vendedor
            Seller s1 = new Seller(1, "Fabio", "fabio@gmail.com", new DateTime(1996, 7, 5), 3000.0, d1);
            Seller s2 = new Seller(2, "Raimunda", "raimunda@gmail.com", new DateTime(1974, 10, 14), 3000.0, d2);
            Seller s3 = new Seller(3, "Antonio", "antonio@gmail.com", new DateTime(1958, 12, 13), 2000.0, d3);
            Seller s4 = new Seller(4, "Rafael", "rafael@gmail.com", new DateTime(2001, 4, 10), 1000.0, d4);
            //Vendas
            SalesRecord r1 = new SalesRecord(1, new DateTime(2021, 03, 29), 5000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2021, 04, 05), 15000.0, SaleStatus.Canceled, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 05, 10), 10000.0, SaleStatus.Pending, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2021, 06, 29), 7000.0, SaleStatus.Billed, s4);
            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(r1, r2, r3, r4);
            _context.SaveChanges();
        }
    }
}
