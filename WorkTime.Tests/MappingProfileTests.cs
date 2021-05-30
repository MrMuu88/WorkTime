using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkTime.Core.Models.Settings;
using WorkTime.Core.Models;
using WorkTime.Mapping;
using WorkTime.ViewModels.DTOs;

namespace WorkTime.Tests
{
	[TestClass]
	public class MappingProfileTests
	{
		public static IMapper Mapper { get; private set; }

		[ClassInitialize]
		public static void InitializeClass(TestContext context)
		{
			Mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();
		}

		[TestMethod]
		public void AppsettingsTest()
		{
			var model = new AppSettings
			{
				DevOps = new DevOpsSettings { BaseUrl = "myurl", PersonalAccessToken = "1234" },
				Menu = new MenuSettings { MyAssignmentsOnly = false, StartMenuAt = WorkItemType.Epic },
				StartWithWindows = false
			};

			var dto = Mapper.Map<AppSettingsDTO>(model);

			Assert.IsTrue(model.DevOps.PersonalAccessToken == dto.DevOps.PersonalAccessToken, "dto.PersonalAccessToken is incorrect");
			Assert.IsTrue(model.Menu.MyAssignmentsOnly == dto.Menu.MyAssignmentsOnly, "dto.MyAsigmentsOnly is incorrect");
			Assert.IsTrue(model.Menu.StartMenuAt == dto.Menu.StartMenuAt, "dto.StartMenuAt is incorrect");

			dto.DevOps.PersonalAccessToken = "qwer";
			var reverse = Mapper.Map(dto, model);

			Assert.IsTrue(reverse.DevOps.BaseUrl == "myurl", "reverse.BaseUrl is incorrect");
			Assert.IsTrue(reverse.DevOps.PersonalAccessToken == dto.DevOps.PersonalAccessToken, "reverse.PersonalAccessToken is incorrect");
			Assert.IsTrue(reverse.Menu.MyAssignmentsOnly == dto.Menu.MyAssignmentsOnly, "reverse.MyAsigmentsOnly is incorrect");
			Assert.IsTrue(reverse.Menu.StartMenuAt == dto.Menu.StartMenuAt, "reverse.StartMenuAt is incorrect");
		}

		[TestMethod]
		public void DevopsSettingsTest()
		{
			var model = new DevOpsSettings { BaseUrl = "myurl",PersonalAccessToken="1234"};
			var dto = Mapper.Map<DevOpsSettingsDTO>(model);
								
			Assert.IsTrue(model.PersonalAccessToken == dto.PersonalAccessToken, "dto.PersonalAccessToken is incorrect");

			dto.PersonalAccessToken = "qwer";
			var reverse = Mapper.Map(dto,model);

			Assert.IsTrue(reverse.BaseUrl == "myurl", "reverse.BaseUrl is incorrect");
			Assert.IsTrue(reverse.PersonalAccessToken == dto.PersonalAccessToken, "reverse.PersonalAccessToken is incorrect");
		}

		[TestMethod]
		public void MenuSettingsTest()
		{
			var model = new MenuSettings { MyAssignmentsOnly = false, StartMenuAt = WorkItemType.Epic };
			var dto = Mapper.Map<MenuSettingsDTO>(model);

			Assert.IsTrue(model.MyAssignmentsOnly == dto.MyAssignmentsOnly, "dto.MyAsigmentsOnly is incorrect");
			Assert.IsTrue(model.StartMenuAt == dto.StartMenuAt, "dto.StartMenuAt is incorrect");

			var reverse = Mapper.Map<MenuSettings>(dto);

			Assert.IsTrue(reverse.MyAssignmentsOnly == dto.MyAssignmentsOnly, "reverse.MyAsigmentsOnly is incorrect");
			Assert.IsTrue(reverse.StartMenuAt == dto.StartMenuAt, "reverse.StartMenuAt is incorrect");

		}
	}
}
