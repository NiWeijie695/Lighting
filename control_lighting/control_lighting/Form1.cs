using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
namespace control_lighting
{
    public partial class Form1 : Form
    {
        private Timer timer;
        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000; // 设置定时器间隔为1秒
            timer.Tick += Timer_Tick;
            timer.Start();



            if (ComputerInfo.WinMajorVersion == 10 && ComputerInfo.WinMinorVersion == 0 && ComputerInfo.DisplayVersion == "23H2")
            {
                label2.Text = "可以使用动态光效";
            }
            else
            {
                label2.Text = "不可以使用动态光效";
            }


            const string keyPath = @"Software\Microsoft\Lighting";
            using (RegistryKey personalizeKey = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (personalizeKey != null)
                {

                    // 获取动态光效的设置值，通常为0（关闭）或1（开启）
                    object dynamicLightingValue = personalizeKey.GetValue("AmbientLightingEnabled");

                    // 根据键值输出状态
                    if (dynamicLightingValue != null && (int)dynamicLightingValue == 1)
                    {
                        label1.Text = "请在Windows设置中禁用动态光效";
                    }
                    else
                    {
                        label1.Text = "选择颜色";
                    }
                }
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            const string keyPath = @"Software\Microsoft\Lighting";
            using (RegistryKey personalizeKey = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (personalizeKey != null)
                {

                    // 获取动态光效的设置值，通常为0（关闭）或1（开启）
                    object dynamicLightingValue = personalizeKey.GetValue("AmbientLightingEnabled");

                    // 根据键值输出状态
                    if (dynamicLightingValue != null && (int)dynamicLightingValue == 1)
                    {
                        label1.Text = "请在Windows设置中禁用动态光效";
                    }
                    else
                    {
                        label1.Text = "选择颜色";
                    }
                }
                else
                {
                    label1.Text = "无法打开动态光效";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:personalization-lighting");

            const string keyPath = @"Software\Microsoft\Lighting";
            using (RegistryKey personalizeKey = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (personalizeKey != null)
                {

                    // 获取动态光效的设置值，通常为0（关闭）或1（开启）
                    object dynamicLightingValue = personalizeKey.GetValue("AmbientLightingEnabled");

                    // 根据键值输出状态
                    if (dynamicLightingValue != null && (int)dynamicLightingValue == 1)
                    {
                        label1.Text = "请在Windows设置中禁用动态光效";
                    }
                    else
                    {
                        label1.Text = "选择颜色";
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            const string keyPath = @"Software\Microsoft\Lighting";
            using (RegistryKey personalizeKey = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (personalizeKey != null)
                {

                    // 获取动态光效的设置值，通常为0（关闭）或1（开启）
                    object dynamicLightingValue = personalizeKey.GetValue("AmbientLightingEnabled");

                    // 根据键值输出状态
                    if (dynamicLightingValue != null && (int)dynamicLightingValue == 1)
                    {
                        label1.Text = "请在Windows设置中禁用动态光效";
                    }
                    else
                    {
                        label1.Text = "选择颜色";
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (ComputerInfo.WinMajorVersion == 10 && ComputerInfo.WinMinorVersion == 0 && ComputerInfo.DisplayVersion == "23H2")
            {
                label2.Text = "可以使用动态光效";
            }
            else
            {
                label2.Text = "不可以使用动态光效";
            }
        }
    }
}
