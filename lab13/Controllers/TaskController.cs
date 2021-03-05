using lab13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet("GetArray")]
        public int [] GetArray ()
        {
            return new Sorting().arr;
        }

        [HttpGet("BubbleSort")]
        public Sorting BubbleSort()
        {
            Sorting sort = new Sorting();
            sort.BubbleSort();
            Sorting sort2 = new Sorting();
            sort2.SwapThreadsCount();
            sort2.BubbleSort();
            sort.effectivityAnalisys2 = sort2.effectivityAnalisys;
            return sort;
        }
        [HttpGet("ShellSort")]
        public Sorting ShellSort()
        {
            Sorting sort = new Sorting();
            sort.SwapThreadsCount();
            sort.ShellSort();
            Sorting sort2 = new Sorting();
            sort2.ShellSort();
            sort2.effectivityAnalisys2 = sort.effectivityAnalisys;
            return sort2;
        }
    }
}
