using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collection
{
    /// <summary>
    /// from:编写高质量代码-改善C#程序的157个建议-建议46：显示释放资源需继承接口IDisposable
    /// </summary>
    public class SampleClass : IDisposable
    {
        // 演示创建一个非托管资源
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        // 演示创建一个托管资源
        private AnotherResource managedResource = new AnotherResource();
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                // 清理托管资源
                if (managedResource!=null)
                {
                    //managedResource.di
                }
            }
        }
    }

    internal class AnotherResource
    {
    }
}
