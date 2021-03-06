﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MATesting.Models;
using MAInstructor.Models;
using MARank.Models;

namespace MATesting
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<StudentContext>(opt => opt.UseInMemoryDatabase("Students"));
      services.AddDbContext<InstructorContext>(opt => opt.UseInMemoryDatabase("Instructors"));
      services.AddDbContext<RankContext>(opt => opt.UseInMemoryDatabase("Ranks"));
      services.AddCors();
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseCors(builder =>
      {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowCredentials();
        builder.AllowAnyOrigin();
      });
      app.UseMvc();
    }
  }
}
