using PrimeSystems.Services;
using PrimeSystems.Models;
using System;
using System.Diagnostics;

namespace PrimeSystems.Core
{
    public static class ActivityLogger
    {
        public static void LogActivity(
            string action,
            string module,
            int? sellId = null,
            int? purchaseId = null,
            int? articleId = null,
            int? clientId = null,
            int? supplierId = null)
        {
            try
            {
                var activityRecordController = new ActivityRecordService();

                var activityRecord = new ActivityRecordModel
                {
                    UserId = Session.CurrentUser?.Id,
                    Module = module,
                    Action = action,
                    Date = DateTime.Now,
                    SellId = sellId,
                    PurchaseId = purchaseId,
                    ArticleId = articleId,
                    ClientId = clientId,
                    SupplierId = supplierId
                };

                bool success = activityRecordController.Create(activityRecord);

                if (success)
                {
                    Debug.WriteLine($"Actividad registrada: {action} en {module}");
                }
                else
                {
                    Debug.WriteLine($"Error al registrar actividad en m�dulo: {module}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepci�n al registrar actividad: {ex.Message}");
            }
        }
    }
}
