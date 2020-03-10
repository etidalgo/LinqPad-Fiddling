<Query Kind="Program" />

void Main()
{
	var fileDateTime = GetMediadentFileStampDateTime("4295285296337140000000XC000001");
	fileDateTime.Dump();
}

// Define other methods and classes here
         DateTime GetMediadentFileStampDateTime(string fileName)
        {
            var FILE_NAME_OFFSET = 11;
            var HOUR_DIVIDER = (1 / (double)24);
            var MINUTE_DIVIDER = (1 / (24 * (double)60));

            // FilenameToLong
            var filenameOut = "";
			var nameLength = fileName.Length;
            for (var iPos = 0; iPos < nameLength; iPos++)
            {
                if (!char.IsDigit(fileName[iPos]) || iPos == FILE_NAME_OFFSET)
                {
                    filenameOut = fileName.Substring(0, iPos);
                    break;
                }
            }
            var filenameAsLong = Convert.ToInt64(filenameOut);

            // GetDateTimeFileInfo
            var dateTimeInfo = Math.Round((filenameAsLong / 1000000d), 7);

            // GetFileCreatedDate
            var dDateTime = new DateTime(1899, 12, 30).AddDays(Math.Floor(dateTimeInfo));

            // GetHourAndMinuteFromDateTime
            var dTime = dateTimeInfo - Math.Floor(dateTimeInfo);
            int hour, minute;
            hour = (int)Math.Floor(dTime / HOUR_DIVIDER);
            dTime -= (hour * HOUR_DIVIDER);
            minute = (int)Math.Floor(dTime / MINUTE_DIVIDER);

            //
            return dDateTime.AddHours(hour).AddMinutes(minute);
        }