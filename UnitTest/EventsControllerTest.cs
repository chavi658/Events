using Api_Calender;
using Api_Calender.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.Collections.Specialized;

namespace UnitTest
{

    public class EventsControllerTest : IDataContext
    {
        readonly EventsController _eventsController;
        readonly Event eve = new Event() { Id = 212, Start = new DateTime(2020, 02, 01), End = new DateTime(2025, 02, 01), Title = "hi" };
        public EventsControllerTest()
        {
            var contex = new DataContextFake();
            _eventsController = new EventsController(contex);
        }

        public List<Event> events { get; set; }

        [Fact]
        public void GetReturnOk()
        {
            //AAA

            //Arrange
            var res = _eventsController.Get();

            //Act
            Assert.IsType<OkObjectResult>(res);
        }
        [Fact]
        public void GetRetutnNotFound()
        {
            int id = 588;
            var res = _eventsController.Get(id);
            Assert.IsType<NotFoundResult>(res);
        }
        [Fact]
        public void PostReturnwithContent()
        {

            var res = _eventsController.Post(eve);

            Assert.IsType<ContentResult>(res);
        }
        [Fact]
        public void DeleateReturn()
        {
            int id = 12;

            var res = _eventsController.Delete(id);
            Assert.IsType<BadRequestObjectResult>(res);
        }

        [Fact]
        public void PutReturn()
        {
            int id = 12;
            var res = _eventsController.Put(id,eve);
            Assert.IsType<OkObjectResult>(res);
        }

    }




}
