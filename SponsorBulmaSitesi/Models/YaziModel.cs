using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SponsorBulmaSitesi.Models
{
    public class YaziModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Icerik { get; set; }
       
    }
}