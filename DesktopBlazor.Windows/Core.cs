using AutoMapper;
using DesktopBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopBlazor.Windows
{
    public class Core
    {
        public static MapperConfiguration Configuration = new MapperConfiguration(cfg => cfg.CreateMap<DesktopBlazor.Shared.Form, System.Windows.Forms.Form>());
        public static System.Windows.Forms.Form CurrentForm;
    }
}
