using BlogExample.Web.Controllers;
using BlogExample.Web.Models.Domain;
using BlogExample.Web.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogExample.Tests.Controller
{
    public class AdminTagsTests
    {
        private ITagRepository _tagRepository;
        private AdminTagsController _adminTagsController;

        public AdminTagsTests() 
        {
            //Repositories
            _tagRepository = A.Fake<ITagRepository>();

            //SUT - System Under Test
            _adminTagsController = new AdminTagsController(_tagRepository);
        }

        #region AddTests
        [Fact]
        public void AdminTags_AddMethodTest_ShouldReturnCorrectModel()
        {
            //Arrange

            //Act
            var result = _adminTagsController.Add();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }

        //TO DO - Implement below
        //[Fact]
        //public void AdminTags_AddMethodTest_ShouldReturnCorrectModel()
        //{
        //    //Arrange -
        //    // 1: mock the tagRepo
        //    // 2: create addTagRequest with data
        //    // 3: can we mock the database call ?

        //    //Act


        //    //Assert

        //}
        #endregion

        #region ListTests
        [Fact]
        public void AdminTags_ListMethodTest_ShouldReturnCorrectType()
        {
            //Arrange - what do I need?
            //var tags = A.Fake<IEnumerable<Tag>>();
            //A.CallTo(() => _tagRepository.GetAllAsync()).Returns(tags);

            //Act - We want to test the controller method.
            var result = _adminTagsController.List();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
        }
        #endregion
    }
}
