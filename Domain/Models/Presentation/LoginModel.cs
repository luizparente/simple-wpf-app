﻿using Domain.Models.Domain;

namespace Domain.Models.Presentation
{
    public class LoginModel {
		public string Username { get; set; }
		public string Password { get; set; }
		public LoginMethod Method { get; set; }
	}
}
