using E_Accounting.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using E_Accounting.Application.Services.CompanyServices;
using MediatR.NotificationPublishers;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Accounting.BackEnd.UnitTest.Features.CompanyFeatures.ReportFeatures
{
    public sealed class RequestReportCommandUnitTest
    {
        private readonly Mock<IReportService> _reportService;

        public RequestReportCommandUnitTest()
        {
            _reportService = new();
        }

        [Fact]
        public async Task GetAllReportsShouldNotBeNull()
        {
            var reports = _reportService.Setup(x => x.GetAllReportsByCompanyId(It.IsAny<string>()));
            reports.ShouldNotBeNull();
        }

        [Fact]
        public async Task RequestReportCommandResponseShouldNotBeNull()
        {
            RequestReportCommand command = new(Name: "Hesap Planı", CompanyId: "");
            RequestReportCommandHandler handler = new(_reportService.Object);
            RequestReportCommandResponse response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
