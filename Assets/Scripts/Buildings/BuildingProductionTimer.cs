using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Buildings
{
    [Serializable]
    public class BuildingProductionTimer
    {
        public delegate void BuildingProductionTimerHandler();
        public event BuildingProductionTimerHandler Ticked;

        [SerializeField] private float _tickTime;

        private CancellationTokenSource tickingTaskTokenSource;
        private Task _tickingTask;

        public void Start()
        {
            tickingTaskTokenSource = new CancellationTokenSource();
            CancellationToken ct = tickingTaskTokenSource.Token;

            _tickingTask = tickingTask(ct);
        }
        public void Stop()
        {
            if (_tickingTask == null)
                return;

            tickingTaskTokenSource.Cancel();
            _tickingTask = null;
        }

        private async Task tickingTask(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            while (true)
            {
                if (ct.IsCancellationRequested)
                    ct.ThrowIfCancellationRequested();

                try
                {
                    Ticked?.Invoke();
                }
                catch (Exception ex)
                {
                    Debug.LogError($"{ex.Message} \n {ex.StackTrace}");
                }
                await Task.Delay((int)(_tickTime * 1000));
            }
        }
    }
}
