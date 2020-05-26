//
// File Name : Observer.cs
// Author : Yuan Sambo
// Author Email: yuan.sambo@gmail.com
// Date Created : 12/04/2020
//

using System;
using System.Collections.Generic;

namespace Observer
{
    // The subscriber or listener 
    public interface ISubscriber
    {
        void OnNotify(Action notif, Channel channel);
    }

    // The publisher 
    public interface IChannel        
    {
        void Subscribe(Account account);
        void UnSubscribe(Account account);
        void Notify();
    }

    // Concrete Publisher
    public class Channel : IChannel     
    {
        // List of subscribers
        List<Account> subs = new List<Account>();    
        List<Video> videos = new List<Video>();
        private string name;

        public Channel(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }


        // Notifies all the subscribed subscribers to this publisher.
        public void Notify()                        
        {
            foreach (var acc in subs)
            {
                acc.OnNotify(UploadedVideo, this);
            }
        }

        // Registers the subscriber to the publisher
        public void Subscribe(Account account)     
        {
            subs.Add(account);
            Console.WriteLine($"You are now subscribed to {name}");
        }

        // Unregisters the subscriber to the publisher
        public void UnSubscribe(Account account)   
        {
            subs.Remove(account);
            Console.WriteLine("You are now unsubscribed");
        }


        void UploadedVideo()
        {
            foreach (var vid in videos)
            {
                Console.WriteLine($"Title : {vid.Title}  Date Uploaded : {vid.Date} \n ");
            }
        }

        public void UploadVideo(string title)
        {
            videos.Add(new Video { Title = title, Date = DateTime.Now });
            Notify();
        }
    }

    // Concrete Subscriber
    public class Account : ISubscriber    
    {
        private string Name { get; set; }

        public Account(string name)
        {
            this.Name = name;
        }
        public void OnNotify(Action notif, Channel channel)
        {
            Console.WriteLine($"Videos of {channel.Name}: \n");
            notif?.Invoke();

        }
    }


    public class Video
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }


    class Youtube
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
