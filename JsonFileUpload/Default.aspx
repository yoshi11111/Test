﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_35Test._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="//unpkg.com/bootstrap/dist/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="//unpkg.com/bootstrap-vue@latest/dist/bootstrap-vue.min.css" />

    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/vue@2.6.10/dist/vue.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
     

    <%-- <script type="text/javascript" src="Scripts/Component.js"></script>--%>
    <style>
        #overlay {
            /*　要素を重ねた時の順番　*/
            z-index: 1;
            /*　画面全体を覆う設定　*/
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0,0,0,0.5);
            /*　画面の中央に要素を表示させる設定　*/
            display: flex;
            align-items: center;
            justify-content: center;
        }
    </style>
</head>
<body>

   
    <div id="app">

        <p>送信するファイルを指定して、［送信］ボタンを押してください。</p>
        <p>
            <input id="ipt_file" type="file" />
          
        </p>
        <p>
            <button v-on:click="jsonTest">button</button>
        </p>
    </div>

    <script type="text/javascript"> 
    
        const app = new Vue({
            el: '#app',
            data: {
                files: null
            },
            //mixins: [Mixin],
            methods: {

                // ■成功例　保存
                jsonTest: function () {

                    var upload_file = $('#ipt_file')[0];
                    var oFile = upload_file.files[0];
                    var m_file_name = oFile.name;

                    var reader = new FileReader();
                    // reader.readAsDataURL(oFile);
                    reader.readAsBinaryString(oFile);

                    //ファイル読込成功イベント
                    reader.onload = function (e) {
                        // データURLスキームを取得
                        var data_url_scheme = reader.result;
                        // データURLスキームからbase64形式のバイナリデータに変換する
                       
                        var base64 = btoa(data_url_scheme);
                        base64 = base64.replace(/^.*,/, '');
                        const options = {
                            headers: { 'Content-Type': 'application/json; charset=utf-8' }
                        };
                        console.log(base64.length);
                        var param = {
                            json: JSON.stringify(base64),
                            name:m_file_name
                        };
                        axios.post('Default.aspx/Test', param, options)
                            .then(function (response) {
                                console.log(response)
                            })
                            .catch(function (error) {
                                console.log(error)
                            });
                    }
                }
            }
        });

    </script>
</body>

</html>

