using System;
using System.Configuration;
using System.IO;
using System.Diagnostics;
namespace git_tools
{
    public class Common
    {
        // Properties
        //      Error Handling
        public static string _AdminEmail = "it@awea.org";
        public static string _Err = "*** Error: ";
        public static string _ErrUnexpected = "There has been an Unexpected Error in the Application. Please try again or <a href='mailto:it@awea.org'>contact support</a>.";
        //      Common
        public static bool _DebugMode = (ConfigurationManager.AppSettings["DebugMode"] == "1");
        public static string _DebugLocation = ConfigurationManager.AppSettings["DebugLocation"];
        // Constructors
        // Methods
        public void Trace(string message, bool addStackFrame = true)
        {
            try
            {
                if (_DebugMode)
                {
                    string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": ";
                    if (addStackFrame)
                    {
                        System.Diagnostics.StackFrame stackframe = new System.Diagnostics.StackFrame(1);
                        msg += stackframe.GetMethod().ReflectedType.FullName + "." + stackframe.GetMethod().Name + " - ";
                    }
                    msg += message;
                    if (message == "")
                    {
                        msg = System.Environment.NewLine + msg;
                    }
                    if (string.IsNullOrEmpty(_DebugLocation))
                    {
                        _DebugLocation = Path.GetTempPath();
                    }
                    StreamWriter tw = new StreamWriter(_DebugLocation + "\\\\iApplications.log", true);
                    tw.WriteLine(msg);
                    tw.Close();
                }
            }
            catch (Exception ex)
            {
                ErrHandle(ex, false);
            }
        }
        public void ErrHandle(Exception ex, bool writeTrace = true)
        {
            if (writeTrace)
            {
                System.Diagnostics.StackFrame stackframe = new System.Diagnostics.StackFrame(1);
                string msg = stackframe.GetMethod().ReflectedType.FullName + "." + stackframe.GetMethod().Name + " - " + ex.Message;
                Trace(_Err + msg, false);
                /// ToDo: Do something else?
            }
        }
        public void ErrHandle(Exception ex, int appId)
        {
            try
            {
                System.Diagnostics.StackFrame stackframe = new System.Diagnostics.StackFrame(1);
                string msg = stackframe.GetMethod().ReflectedType.FullName + "." + stackframe.GetMethod().Name + " - " + ex.Message;
                // Write to Trace Log
                Trace(_Err + msg, false);
//                // Send email to SysAdmin
//                Email blE = new Email();
//                blE.SendMailMessage("iApplications", _AdminEmail, "", "", "iApplications Error", msg);
//                // Write to Event Log
//                WriteEventLog("iApplications", msg);
                // Create record in Bug Tracker
                //WriteAppErr(appId, userId, stackframe.GetMethod().ReflectedType.FullName, msg, loginGuid);
            }
            catch (Exception e)
            {
                ErrHandle(e);
            }
        }
        public void ErrHandle(Exception ex, int appId, ref System.Windows.Forms.Label lblError)
        {
            try
            {
                ErrHandle(ex, appId);
                lblError.Text = _ErrUnexpected + System.Environment.NewLine + "( " + ex.Message + " )";
            }
            catch (Exception e)
            {
                ErrHandle(e);
            }
        }
        public void WriteEventLog(string strSource, string msg)
        {
            try
            {
                Trace(" ");
                // create a regkey HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\eventlog\Application\MyApp;
                // inside, create a string value EventMessageFile and set its value to e.g. 
                // C:\Windows\Microsoft.NET\Framework\v4.0.30319\EventLogMessages.dll
                if (!EventLog.SourceExists(strSource))
                {
                    EventLog.CreateEventSource(strSource, "Application");
                }
                EventLog.WriteEntry(strSource, msg, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                ErrHandle(ex);
            }
        }
    }
}
