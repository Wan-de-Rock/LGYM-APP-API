namespace LgymApp.Domain.Helpers;

public static class GuidHelpers
{
    public static DateTimeOffset GetDateTimeOffset(this Guid uuid) 
    {
        byte[] bytes = new byte[8];
        uuid.ToByteArray(true)[0..6].CopyTo(bytes, 2);
        if (BitConverter.IsLittleEndian) 
        {
            Array.Reverse(bytes);
        }
        long ms = BitConverter.ToInt64(bytes);
        return DateTimeOffset.FromUnixTimeMilliseconds(ms);
    }
}