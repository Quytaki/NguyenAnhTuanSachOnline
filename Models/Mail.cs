﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.CodeDom.Compiler;

namespace NguyenAnhTuanSachOnline.Models
{
    public class Mail
    {
        public string Form { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public string Attachment { get; set; }
    }
}