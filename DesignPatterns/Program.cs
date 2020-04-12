using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel MukbangChannel = new Channel("Zach Choi");
            Channel TulfoChannel = new Channel("Raffy Tulfo in Action");
            Account account = new Account("Yuan Sambo");

            MukbangChannel.Subscribe(account);
            MukbangChannel.UploadVideo("Borex ASMR");
            MukbangChannel.UploadVideo("Ton Ton's Mukbang Challenge");
            TulfoChannel.Subscribe(account);
            TulfoChannel.UploadVideo("Professor hindi nag tuturo inireklamo ng estudyante.");
        }
    }
}
