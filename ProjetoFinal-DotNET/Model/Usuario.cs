﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Model
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}