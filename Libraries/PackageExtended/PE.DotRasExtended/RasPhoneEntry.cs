using PE.DotRasExtended.Results;
using System;

namespace PE.DotRasExtended
{

    public class RasPhoneEntry
    {

        public static bool ContainsEntry(string entryName)
        {
            using (var book = new RasPhoneBookEx())
            {
                return book.Contains(entryName);
            }
        }

        public static CreateEntryResult CreateL2TPAsync(string entryName, string userName, string password)
        {
            try
            {
                using (var book = new RasPhoneBookEx())
                {
                    if (!book.UsableL2TP()) return new CreateEntryResult(Properties.Resources.ErrorMessage002);
                    if (book.Contains(entryName)) return new CreateEntryResult(Properties.Resources.ErrorMessage003);

                    book.CreateL2TP(entryName, userName, password);

                    return new CreateEntryResult();
                }
            }
            catch (Exception)
            {
                return new CreateEntryResult(Properties.Resources.ErrorMessage001);
            }
        }

        public static CreateEntryResult CreateVpnL2TPAsync(string entryName, string userName, string password)
        {
            using (var book = new RasPhoneBookEx())
            {
                try
                {
                    if (!book.UsableL2TP()) return new CreateEntryResult(Properties.Resources.ErrorMessage002);

                    book.CreateL2TP(entryName, userName, password);

                    return new CreateEntryResult();
                }
                catch (Exception)
                {
                    return new CreateEntryResult(Properties.Resources.ErrorMessage005);
                }
            }
        }

        public static DialResult ConnectTestAsync(string entryName, string userName, string password)
        {
            using (var book = new RasPhoneBookEx())
            {
                using (var dialer = new RasDialerEx(entryName, userName, password))
                {
                    try
                    {
                        if (!book.UsableL2TP()) return new DialResult(Properties.Resources.ErrorMessage002);

                        book.CreateL2TP(entryName, userName, password);
                        dialer.Dial();

                        return new DialResult();
                    }
                    catch (Exception)
                    {
                        return new DialResult(Properties.Resources.ErrorMessage004);
                    }
                    finally
                    {
                        if (dialer.Opend) dialer.HangUp();
                        if (book.Contains(entryName)) book.RemoveEntry(entryName);
                    }
                }
            }
        }

    }
}
