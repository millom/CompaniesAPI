﻿using Companies.Presentation.TestControllersOnlyForDemo;
using Domain.Contracts;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Tests;
public class RepositoryControllerTests
{
    private Mock<ICompanyRepository> mockRepo;
    private RepositoryController sut;

    public RepositoryControllerTests()
    {
        mockRepo = new Mock<ICompanyRepository>();
        sut = new RepositoryController(mockRepo.Object);
    }

    [Fact]
    public async Task GetCompany_ShouldReturnAllCompanies()   
    {
        //Arrange
        var companies = GetCompanys();
        mockRepo.Setup(m => m.GetCompaniesAsync(false, It.IsAny<bool>())).ReturnsAsync(companies);

        //Act
        var result = await sut.GetCompany(false);

        //Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
        var items = Assert.IsType<List<Company>>(okObjectResult.Value);
        Assert.Equal(items.Count, companies.Count);
    }

    private List<Company> GetCompanys()
    {
        return new List<Company>
            {
                new Company
                {
                     Id = Guid.NewGuid(),
                     Name = "Test",
                     Address = "Ankeborg, Sweden",
                     Employees = new List<ApplicationUser>()
                },
                 new Company
                {
                     Id = Guid.NewGuid(),
                     Name = "Test",
                     Address = "Ankeborg, Sweden",
                     Employees = new List<ApplicationUser>()
                }
            };

    }
}
