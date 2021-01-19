using HSB.Models;
using HSB.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSB.Services
{
    public class ExportDataService<T> : IExportDataService<T>
    {

        private IHostingEnvironment _env;

        public ExportDataService(IHostingEnvironment env)
        {
            this._env = env;
        }

        public byte[] CreateMembersFile(IEnumerable<Member> members)
        {
            var sb = new StringBuilder();

            sb.Append("FirstName;LastName;E-mail;MobilePay;Subscribed;PhoneNo" + Environment.NewLine);

            foreach (var item in members)
            {
                sb.AppendFormat("{0};{1};{2};{3};{4};{5}{6}", item.FirstName, item.LastName, item.Email,
                    item.MobilePay, item.Subscribed, item.PhoneNo, Environment.NewLine);
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return Encoding.GetEncoding(1252).GetBytes(sb.ToString());
        }

    }
}
