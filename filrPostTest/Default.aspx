<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RealEstate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="app">

        <%-- 方法１ --%>
        <button v-on:click="upload">button</button>

        <%-- 方法２ --%>
        <%--   <input id="ipt_file" type="file" />
        <a href='#' onclick="UploadFile();" data-role='button'>Upload</a>--%>



        <%-- 通常POST --%>
        <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
            <p>送信するファイルを指定して、［送信］ボタンを押してください。</p>
            <p>
                <input type="file" name="userfile" id="userfile">
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="送信" />
            </p>
        </form>
    </div>






    <script>
     
        const app = new Vue({
            el: '#app',
            data: {
                senddata: {
                    file: 'test'
                }
            },
            methods: {

                selectedFile: function (e) {
                    // 選択された File の情報を保存しておく
                    e.preventDefault();
                    let files = e.target.files;
                    this.file = files[0];


                },
                upload: function () {

                    var form = $('#Form1').get()[0];
                    var params = new FormData(form);
                    const options = {
                        headers: { 'content-type': 'multipart/form-data' }
                    };

                    axios.post('Default.aspx/Test', params, options)
                        .then(function (response) {
                            // 成功時
                        })
                        .catch(function (error) {
                            // エラー時
                        });
                },
                jsonTest: function () {

                    const options = {
                        headers: { 'Content-Type': 'application/json;charset=utf-8' }
                    };

                    axios.post('Default.aspx/Test', params, options)
                        .then(res => {
                            console.log(res.headers);
                        })
                        .catch(err => {
                            // 略
                        });
                }
            }
        });
    </script>
</asp:Content>
