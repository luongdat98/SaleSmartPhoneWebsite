//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace my_phone.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class productdetail
    {
        public int id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> color_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public string img_url { get; set; }
        public string screen { get; set; }
        public string oper_sys { get; set; }
        public string rear_camera { get; set; }
        public string front_camera { get; set; }
        public string cpu { get; set; }
        public string ram { get; set; }
        public string cart_sim { get; set; }
        public string internal_memory { get; set; }
        public string battery_capacity { get; set; }
        public Nullable<int> active { get; set; }
        public System.DateTime create_date { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
    
        public virtual color color { get; set; }
        public virtual product product { get; set; }
    }
}
