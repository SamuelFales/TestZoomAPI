using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApiZoom.Models
{
 
    public class Occurrence
    {
        public string occurrence_id { get; set; }
        public string start_time { get; set; }
        public string duration { get; set; }
        public string status { get; set; }
    }

    public class Settings
    {
        public string host_video { get; set; }
        public string participant_video { get; set; }
        public string cn_meeting { get; set; }
        public string in_meeting { get; set; }
        public string join_before_host { get; set; }
        public string mute_upon_entry { get; set; }
        public string watermark { get; set; }
        public string use_pmi { get; set; }
        public string approval_type { get; set; }
        public string registration_type { get; set; }
        public string audio { get; set; }
        public string auto_recording { get; set; }
        public string enforce_login { get; set; }
        public string enforce_login_domains { get; set; }
        public string alternative_hosts { get; set; }
    }

    public class Meeting
    {

        public Meeting(string topico)
        {
            this.topic = topico;
        }

        public string uuid { get; set; }
        public string id { get; set; }
        public string host_id { get; set; }
        public string topic { get; set; }
        public string type { get; set; }
        public string start_time { get; set; }
        public string duration { get; set; }
        public string timezone { get; set; }
        public string created_at { get; set; }
        public string agenda { get; set; }
        public string start_url { get; set; }
        public string join_url { get; set; }
        public string password { get; set; }
        public string h323_password { get; set; }
        public List<Occurrence> occurrences { get; set; }
        public Settings settings { get; set; }
    }


    public class Meetings
    {
        public string page_count { get; set; }
        public string page_number { get; set; }
        public string page_size { get; set; }
        public string total_records { get; set; }
        public List<Meeting> meetings { get; set; }
    }


}