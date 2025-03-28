﻿using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2018, 1, 1);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");

            if (!maxDate.HasValue)
            { 
                maxDate = maxDate = new DateTime(2018, 12, 31);
            }
            
            ViewData["maxDate"]= maxDate.Value.ToString("yyyy-MM-dd");
            var result  = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        } 
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2018, 1, 1);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");

            if (!maxDate.HasValue)
            { 
                maxDate = maxDate = new DateTime(2018, 12, 31);
            }
            
            ViewData["maxDate"]= maxDate.Value.ToString("yyyy-MM-dd");
            var result  = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }

    }
}
