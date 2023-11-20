﻿using Microsoft.AspNetCore.Identity;
using ShoesShop.DAL.Entities;
using System.Security.Claims;

namespace ShoesShop.DAL.Helpers;

public static class ExternalLoginHelper
{
	private static string GetAvatarLink(ExternalLoginInfo info)
	{
		const string defaultAvatar = "https://i.imgur.com/LIorKnU.jpg";
		var loginProvider =
			info.LoginProvider
				.ToLower(); //string.Equals(model.Email, payload.Email, StringComparison.OrdinalIgnoreCase)
		var avatarLink = "";
		var claims = info.Principal.Claims;
		var gg = claims.SingleOrDefault(c => c.Type == "Picture")?.Value;

		avatarLink = loginProvider switch
		{
			"facebook" => $"https://graph.facebook.com/{info.ProviderKey}/picture?type=large",
			"google" => string.IsNullOrEmpty(gg) ? defaultAvatar : gg,
			"github" => $"https://avatars.githubusercontent.com/u/{info.ProviderKey}?",
			_ => defaultAvatar
		};

		return avatarLink;
	}

	private static string GetEmailGithub(string? userName, string? urlPublic)
	{
		return $"{userName}@gmail.com";
	}

	public static AppUser ToNewUser(ExternalLoginInfo info)
	{
		var email = info.Principal.FindFirstValue(ClaimTypes.Email);
		var guidId = Guid.NewGuid().ToString().Split("-")[0];
		var name = info.Principal.Identity?.Name;

		if (email == null && info.ProviderDisplayName.ToLower().Equals("github"))
		{
			//urn:github:url
			var urlPublic = info.Principal.Claims.FirstOrDefault(s => s.Type.Equals("urn:github:url"))?.Value;
			email = GetEmailGithub(name, urlPublic);
		}

		if (string.IsNullOrEmpty(name)) name = "CodeBug";
		if (string.IsNullOrEmpty(email)) email = $"can_not_get_your_email{guidId}@gmail.com";

		var uname = name.Split(" ")[0];
		var username = uname + guidId;

		return new AppUser()
		{
			Email = email,
			Picture = GetAvatarLink(info),
			FullName = name.RemoveAllNumber(),
			UserName = username.VietnameseToNormalString(),
			NickName = username.VietnameseToNormalString(),
			CreatedBy = info.ProviderDisplayName,
			CreatedAt = DateTime.Now
		};
	}
}