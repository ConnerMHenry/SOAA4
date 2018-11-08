﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestClient.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RestClient
{
    public partial class ActionPage : System.Web.UI.Page
    {
        public Action action;
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    string actionStr = Request.QueryString["action"];

            //    switch (actionStr)
            //    {
            //        case "Delete":
            //            action = Action.Delete;
            //            break;

            //        case "Update":
            //            action = Action.Update;
            //            break;

            //        case "Insert":
            //            action = Action.Insert;
            //            break;

            //        default:
            //            action = Action.Search;
            //            break;
            //    }

            //}
            //catch
            //{
            //    action = Action.Search;
            //}

            //SetupUI();
        }

        protected void searchLbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ActionPage.aspx?action=Search");
        }

        protected void insertLbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ActionPage.aspx?action=Insert");
        }

        protected void updateLbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ActionPage.aspx?action=Update");
        }

        protected void deleteLbl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ActionPage.aspx?action=Delete");
        }

        public void SetupUI()
        {
            //switch (action)
            //{
            //    case Action.Delete:
            //        ExecuteBtn.Text = "Delete";
            //        break;

            //    case Action.Update:
            //        ExecuteBtn.Text = "Update";
            //        break;

            //    case Action.Insert:
                    
            //        ExecuteBtn.Text = "Insert";
            //        break;

            //    default:
            //        ExecuteBtn.Text = "Search";
            //        break;
            //}
            
        }

        protected void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            //Customer cust = new Customer()
            //{
            //    firstName = txtFirstName.Text,
            //    lastName = txtLastName.Text,
            //    phoneNumber = txtPhoneNumber.Text
            //};

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ////HttpContent content = new StringContent(Json.Encode(cust));
            //try
            //{
            //    HttpResponseMessage response = client.PostAsJsonAsync<Customer>("Customer/add", cust).Result;
            //    Console.WriteLine(response.ToString());
            //}
            //catch (Exception exceptional)
            //{
            //    Console.WriteLine(exceptional.Message);
            //}

        }

        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            //Customer cust = new Customer()
            //{
            //    firstName = txtFirstName.Text,
            //    lastName = txtLastName.Text,
            //    phoneNumber = txtPhoneNumber.Text
            //};

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:55040/api/v1/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ////HttpContent content = new StringContent(Json.Encode(cust));
            //try
            //{
            //    HttpResponseMessage response = client.PostAsJsonAsync<Customer>("Customer/add", cust).Result;
            //    Console.WriteLine(response.ToString());
            //}
            //catch (Exception exceptional)
            //{
            //    Console.WriteLine(exceptional.Message);
            //}

        }

        protected void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            //CustomerChk.Visible = true;
        }

        protected void AddCartBtn_Click(object sender, EventArgs e)
        {

        }

        protected void AddOrderBtn_Click(object sender, EventArgs e)
        {

        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            ProductChk.Visible = true;
        }
    }
}