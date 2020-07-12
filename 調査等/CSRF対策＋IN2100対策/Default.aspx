<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="app">
        <h2>TEST</h2>
        <button v-on:click="csrTest">csrTest</button>
        <input type="hidden" value="testCSRF" name="__RequestVerificationToken" />
    </div>
    <script type="text/javascript">
  
        var app = new Vue({
            el: '#app',
            data: {
                dataObj: {}
            },
            methods: {
                csrTest: function () {
                  
                    const options = {
                        headers: {
                            'Content-Type': 'application/json; charset=utf-8',
                        }
                    };

                   // console.log(e);
                    param = { json: JSON.stringify(app.dataObj) };
                    axios.post('Default.aspx/DoPost', param, options)
                        .then(function (response) {
                            // app.dataObj = JSON.parse(response.data.d);
                        })
                        .catch(function (error) {
                            console.log(error);
                        });
                }
            }
        })

    </script>
</asp:Content>
