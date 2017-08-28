using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;

namespace GetMyComputerType
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "User Computer Type";

			Console.WriteLine("\n\tPC Type >> " + GetComputerType() + "\n\n");
			Console.WriteLine("\tPress and key to exit.");
			Console.ReadKey(true);
		}

		/// <summary>
		/// Returns the type of computer that is currently in using.
		/// <para>[현재 사용중인 컴퓨터의 타입을 반환합니다.]</para>
		/// </summary>
		/// <returns>PC Type</returns>
		public static string GetComputerType()
		{
			string result = string.Empty;

			try
			{
				ManagementObjectSearcher query = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SystemEnclosure");

				foreach (ManagementObject queryObj in query.Get())
				{
					if (queryObj["ChassisTypes"] != null)
					{
						ushort[] arrChassisTypes = (ushort[])(queryObj["ChassisTypes"]);
						foreach (ushort arrValue in arrChassisTypes)
						{
							switch (arrValue)
							{
								case 1:
									result = "Other";
									break;
								case 2:
									result = "Unknown";
									break;
								case 3:
									result = "Desktop";
									break;
								case 4:
									result = "Low Profile Desktop";
									break;
								case 5:
									result = "Pizza Box";
									break;
								case 6:
									result = "Mini Tower";
									break;
								case 7:
									result = "Tower";
									break;
								case 8:
									result = "Portable";
									break;
								case 9:
									result = "Laptop";
									break;
								case 10:
									result = "Notebook";
									break;
								case 11:
									result = "Hand Held";
									break;
								case 12:
									result = "Docking Station";
									break;
								case 13:
									result = "All in One";
									break;
								case 14:
									result = "Sub Notebook";
									break;
								case 15:
									result = "Space-Saving";
									break;
								case 16:
									result = "Lunch Box";
									break;
								case 17:
									result = "Main System Chassis";
									break;
								case 18:
									result = "Expansion Chassis";
									break;
								case 19:
									result = "SubChassis";
									break;
								case 20:
									result = "Bus Expansion Chassis";
									break;
								case 21:
									result = "Peripheral Chassis";
									break;
								case 22:
									result = "Storage Chassis";
									break;
								case 23:
									result = "Rack Mount Chassis";
									break;
								case 24:
									result = "Sealed-Case PC";
									break;
							}
						}
					}
				}
				return result;
			}
			catch (ManagementException e)
			{
				Debug.WriteLine("Error : " + e.Message);
				return "Error.. \nErrorMessage\n" + e.Message;
			}
		}
	}
}
