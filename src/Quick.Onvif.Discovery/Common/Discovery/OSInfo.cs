using System;
using System.Runtime.InteropServices;

namespace Quick.Onvif.Discovery.Common.Discovery;

public static class OSInfo
{
	private struct OSVERSIONINFOEX
	{
		public int dwOSVersionInfoSize;

		public int dwMajorVersion;

		public int dwMinorVersion;

		public int dwBuildNumber;

		public int dwPlatformId;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string szCSDVersion;

		public short wServicePackMajor;

		public short wServicePackMinor;

		public short wSuiteMask;

		public byte wProductType;

		public byte wReserved;
	}

	private static string s_Edition;

	private static string s_Name;

	private const int PRODUCT_UNDEFINED = 0;

	private const int PRODUCT_ULTIMATE = 1;

	private const int PRODUCT_HOME_BASIC = 2;

	private const int PRODUCT_HOME_PREMIUM = 3;

	private const int PRODUCT_ENTERPRISE = 4;

	private const int PRODUCT_HOME_BASIC_N = 5;

	private const int PRODUCT_BUSINESS = 6;

	private const int PRODUCT_STANDARD_SERVER = 7;

	private const int PRODUCT_DATACENTER_SERVER = 8;

	private const int PRODUCT_SMALLBUSINESS_SERVER = 9;

	private const int PRODUCT_ENTERPRISE_SERVER = 10;

	private const int PRODUCT_STARTER = 11;

	private const int PRODUCT_DATACENTER_SERVER_CORE = 12;

	private const int PRODUCT_STANDARD_SERVER_CORE = 13;

	private const int PRODUCT_ENTERPRISE_SERVER_CORE = 14;

	private const int PRODUCT_ENTERPRISE_SERVER_IA64 = 15;

	private const int PRODUCT_BUSINESS_N = 16;

	private const int PRODUCT_WEB_SERVER = 17;

	private const int PRODUCT_CLUSTER_SERVER = 18;

	private const int PRODUCT_HOME_SERVER = 19;

	private const int PRODUCT_STORAGE_EXPRESS_SERVER = 20;

	private const int PRODUCT_STORAGE_STANDARD_SERVER = 21;

	private const int PRODUCT_STORAGE_WORKGROUP_SERVER = 22;

	private const int PRODUCT_STORAGE_ENTERPRISE_SERVER = 23;

	private const int PRODUCT_SERVER_FOR_SMALLBUSINESS = 24;

	private const int PRODUCT_SMALLBUSINESS_SERVER_PREMIUM = 25;

	private const int PRODUCT_HOME_PREMIUM_N = 26;

	private const int PRODUCT_ENTERPRISE_N = 27;

	private const int PRODUCT_ULTIMATE_N = 28;

	private const int PRODUCT_WEB_SERVER_CORE = 29;

	private const int PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT = 30;

	private const int PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY = 31;

	private const int PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING = 32;

	private const int PRODUCT_SERVER_FOR_SMALLBUSINESS_V = 35;

	private const int PRODUCT_STANDARD_SERVER_V = 36;

	private const int PRODUCT_ENTERPRISE_SERVER_V = 38;

	private const int PRODUCT_STANDARD_SERVER_CORE_V = 40;

	private const int PRODUCT_ENTERPRISE_SERVER_CORE_V = 41;

	private const int PRODUCT_HYPERV = 42;

	private const int VER_NT_WORKSTATION = 1;

	private const int VER_NT_DOMAIN_CONTROLLER = 2;

	private const int VER_NT_SERVER = 3;

	private const int VER_SUITE_SMALLBUSINESS = 1;

	private const int VER_SUITE_ENTERPRISE = 2;

	private const int VER_SUITE_TERMINAL = 16;

	private const int VER_SUITE_DATACENTER = 128;

	private const int VER_SUITE_SINGLEUSERTS = 256;

	private const int VER_SUITE_PERSONAL = 512;

	private const int VER_SUITE_BLADE = 1024;

	public static int Bits => IntPtr.Size * 8;

	public static string Edition
	{
		get
		{
			if (s_Edition != null)
			{
				return s_Edition;
			}
			string result = string.Empty;
			OperatingSystem oSVersion = Environment.OSVersion;
			OSVERSIONINFOEX osVersionInfo = default(OSVERSIONINFOEX);
			osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));
			if (GetVersionEx(ref osVersionInfo))
			{
				int major = oSVersion.Version.Major;
				int minor = oSVersion.Version.Minor;
				byte wProductType = osVersionInfo.wProductType;
				short wSuiteMask = osVersionInfo.wSuiteMask;
				switch (major)
				{
				case 4:
					switch (wProductType)
					{
					case 1:
						result = "Workstation";
						break;
					case 3:
						result = (((wSuiteMask & 2) == 0) ? "Standard Server" : "Enterprise Server");
						break;
					}
					break;
				case 5:
					switch (wProductType)
					{
					case 1:
						result = (((wSuiteMask & 0x200) == 0) ? "Professional" : "Home");
						break;
					case 3:
						result = ((minor != 0) ? (((wSuiteMask & 0x80) == 0) ? (((wSuiteMask & 2) == 0) ? (((wSuiteMask & 0x400) == 0) ? "Standard" : "Web Edition") : "Enterprise") : "Datacenter") : (((wSuiteMask & 0x80) == 0) ? (((wSuiteMask & 2) == 0) ? "Server" : "Advanced Server") : "Datacenter Server"));
						break;
					}
					break;
				case 6:
				{
					if (GetProductInfo(major, minor, osVersionInfo.wServicePackMajor, osVersionInfo.wServicePackMinor, out var edition))
					{
						switch (edition)
						{
						case 6:
							result = "Business";
							break;
						case 16:
							result = "Business N";
							break;
						case 18:
							result = "HPC Edition";
							break;
						case 8:
							result = "Datacenter Server";
							break;
						case 12:
							result = "Datacenter Server (core installation)";
							break;
						case 4:
							result = "Enterprise";
							break;
						case 27:
							result = "Enterprise N";
							break;
						case 10:
							result = "Enterprise Server";
							break;
						case 14:
							result = "Enterprise Server (core installation)";
							break;
						case 41:
							result = "Enterprise Server without Hyper-V (core installation)";
							break;
						case 15:
							result = "Enterprise Server for Itanium-based Systems";
							break;
						case 38:
							result = "Enterprise Server without Hyper-V";
							break;
						case 2:
							result = "Home Basic";
							break;
						case 5:
							result = "Home Basic N";
							break;
						case 3:
							result = "Home Premium";
							break;
						case 26:
							result = "Home Premium N";
							break;
						case 42:
							result = "Microsoft Hyper-V Server";
							break;
						case 30:
							result = "Windows Essential Business Management Server";
							break;
						case 32:
							result = "Windows Essential Business Messaging Server";
							break;
						case 31:
							result = "Windows Essential Business Security Server";
							break;
						case 24:
							result = "Windows Essential Server Solutions";
							break;
						case 35:
							result = "Windows Essential Server Solutions without Hyper-V";
							break;
						case 9:
							result = "Windows Small Business Server";
							break;
						case 7:
							result = "Standard Server";
							break;
						case 13:
							result = "Standard Server (core installation)";
							break;
						case 40:
							result = "Standard Server without Hyper-V (core installation)";
							break;
						case 36:
							result = "Standard Server without Hyper-V";
							break;
						case 11:
							result = "Starter";
							break;
						case 23:
							result = "Enterprise Storage Server";
							break;
						case 20:
							result = "Express Storage Server";
							break;
						case 21:
							result = "Standard Storage Server";
							break;
						case 22:
							result = "Workgroup Storage Server";
							break;
						case 0:
							result = "Unknown product";
							break;
						case 1:
							result = "Ultimate";
							break;
						case 28:
							result = "Ultimate N";
							break;
						case 17:
							result = "Web Server";
							break;
						case 29:
							result = "Web Server (core installation)";
							break;
						}
					}
					break;
				}
				}
			}
			s_Edition = result;
			return result;
		}
	}

	public static string Name
	{
		get
		{
			if (s_Name != null)
			{
				return s_Name;
			}
			string result = "unknown";
			OperatingSystem oSVersion = Environment.OSVersion;
			OSVERSIONINFOEX osVersionInfo = default(OSVERSIONINFOEX);
			osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));
			if (GetVersionEx(ref osVersionInfo))
			{
				int major = oSVersion.Version.Major;
				int minor = oSVersion.Version.Minor;
				switch (oSVersion.Platform)
				{
				case PlatformID.Win32Windows:
					if (major == 4)
					{
						string szCSDVersion = osVersionInfo.szCSDVersion;
						switch (minor)
						{
						case 0:
							result = ((!(szCSDVersion == "B") && !(szCSDVersion == "C")) ? "Windows 95" : "Windows 95 OSR2");
							break;
						case 10:
							result = ((!(szCSDVersion == "A")) ? "Windows 98" : "Windows 98 Second Edition");
							break;
						case 90:
							result = "Windows Me";
							break;
						}
					}
					break;
				case PlatformID.Win32NT:
				{
					byte wProductType = osVersionInfo.wProductType;
					switch (major)
					{
					case 3:
						result = "Windows NT 3.51";
						break;
					case 4:
						switch (wProductType)
						{
						case 1:
							result = "Windows NT 4.0";
							break;
						case 3:
							result = "Windows NT 4.0 Server";
							break;
						}
						break;
					case 5:
						switch (minor)
						{
						case 0:
							result = "Windows 2000";
							break;
						case 1:
							result = "Windows XP";
							break;
						case 2:
							result = "Windows Server 2003";
							break;
						}
						break;
					case 6:
						switch (wProductType)
						{
						case 1:
							switch (minor)
							{
							case 0:
								result = "Windows Vista";
								break;
							case 1:
								result = "Windows 7";
								break;
							}
							break;
						case 3:
							result = "Windows Server 2008";
							break;
						}
						break;
					}
					break;
				}
				}
			}
			s_Name = result;
			return result;
		}
	}

	public static string ServicePack
	{
		get
		{
			string result = string.Empty;
			OSVERSIONINFOEX osVersionInfo = default(OSVERSIONINFOEX);
			osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));
			if (GetVersionEx(ref osVersionInfo))
			{
				result = osVersionInfo.szCSDVersion;
			}
			return result;
		}
	}

	public static int BuildVersion => Environment.OSVersion.Version.Build;

	public static string VersionString => Environment.OSVersion.Version.ToString();

	public static Version Version => Environment.OSVersion.Version;

	public static int MajorVersion => Environment.OSVersion.Version.Major;

	public static int MinorVersion => Environment.OSVersion.Version.Minor;

	public static int RevisionVersion => Environment.OSVersion.Version.Revision;

	[DllImport("Kernel32.dll")]
	internal static extern bool GetProductInfo(int osMajorVersion, int osMinorVersion, int spMajorVersion, int spMinorVersion, out int edition);

	[DllImport("kernel32.dll")]
	private static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);
}
