using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersNet.vCard.Web.Controllers
{
    public class vCardActionResult : IActionResult
    {
        private readonly string _vCardName;

        public vCardActionResult(string vCardName)
        {
            _vCardName = vCardName;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var vcard = System.IO.File.ReadAllText($"vCards/{_vCardName}.vcf");

            var fileName = $"{_vCardName}.vcf";
            var disposition = "attachment; filename=" + fileName;

            var response = context.HttpContext.Response;
            response.ContentType = "text/vcard";
            response.Headers.Add("Content-disposition", disposition);

            var bytes = Encoding.UTF8.GetBytes(vcard);

            await response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
