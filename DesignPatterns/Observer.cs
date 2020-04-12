//
// File Name : Observer.cs
// Author : Yuan Sambo
// Date Created : 12/04/2020 
//
//
//
using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public interface ISubscriber
    {
        public delegate void Notification();

        void OnNotify(Notification notif, Channel channel);
    }


    public interface IChannel
    {
        void Subscribe(Account account);
        void UnSubscribe(Account account);
        void Notify();
    }

    public class Channel : IChannel
    {
        List<Account> subs = new System.Collections.Generic.List<Account>();
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



        public void Notify()
        {
            foreach (var acc in subs)
            {
                acc.OnNotify(UploadedVideo, this);
            }
        }

        public void Subscribe(Account account)
        {
            subs.Add(account);
            Console.WriteLine($"You are now subscribed to {name}");
        }

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


    public class Account : ISubscriber
    {

        public string name { get; set; }

        public Account(string name)
        {
            this.name = name;
        }
        public void OnNotify(ISubscriber.Notification notif, Channel channel)
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
}
