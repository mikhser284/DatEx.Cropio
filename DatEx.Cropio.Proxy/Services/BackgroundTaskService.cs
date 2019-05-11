using DatEx.Cropio.BaseAPI;
using DatEx.Cropio.Proxy.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DatEx.Cropio.Proxy.Services
{
    


    public class BackgroundTaskService : IHostedService, IDisposable
    {
        private IServiceProvider _serviceProvider;
        private ILogger _logger;
        private DbContextCropioProxy _dbContext = null;
        private Int32 MaxBookId = 0;
        private Timer _timer;

        public BackgroundTaskService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger("FileLogger");
            var api = CropioApi.CreateUsingConfigFile();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("• StartAsync");
            try
            {
                _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(60));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "■ Произошла ошибка");
            }
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void DoWork(object state)
        {
            DateTime currentTime = DateTime.Now;
            _logger.LogInformation($"• Start DB syncronization - Started at {currentTime}");
            //
            using(IServiceScope scope = _serviceProvider.CreateScope())
            {
                _dbContext = scope.ServiceProvider.GetRequiredService<DbContextCropioProxy>();                
                var api = CropioApi.CreateUsingConfigFile();                
                //
                foreach(var ids in api.GetObjectsIds<CO_User>().Data.Paginate(100))
                {
                    foreach(var e in api.GetObjects<CO_User>(ids).Data)
                    {
                        var user = User.FromCropioObj(e);
                        _dbContext.Users.Add(user);
                    }
                    _dbContext.SaveChanges();                    
                }
                _logger.LogInformation($"  DB syncronization - Users synchronized at {currentTime}");
                //
                foreach(var ids in api.GetObjectsIds<CO_Alert>().Data.Paginate(100))
                {
                    foreach(var e in api.GetObjects<CO_Alert>(ids).Data)
                    {
                        var alert = Alert.FromCropioObj(e);
                        _dbContext.Alerts.Add(alert);
                    }
                    _dbContext.SaveChanges();                    
                }
                _logger.LogInformation($"  DB syncronization - Alerts synchronized at {currentTime}");
                _logger.LogInformation($"• DB syncronization - Finished at 4{currentTime}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("• StopAsync");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
