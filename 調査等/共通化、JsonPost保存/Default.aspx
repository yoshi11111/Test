<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_35Test._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="//unpkg.com/bootstrap/dist/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="//unpkg.com/bootstrap-vue@latest/dist/bootstrap-vue.min.css" />

    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/vue@2.6.10/dist/vue.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>


     <script type="text/javascript" src="Scripts/Component.js"></script>
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
          <%--  <input id="ipt_file" type="file" />--%>
            <%--<input id="file1" type="file" name="file1" />--%>
        </p>
        <p>
            <%--  <button v-on:click="hello">hello</button>--%>
          <%--  <button v-on:click="doPost('<%=POST_TYPE_DELTE%>')">delete</button>
            <button v-on:click="jsonTest('<%=POST_TYPE_SELECT%>')">select</button>--%>
        </p>
        <%-- </form>--%>
       <%-- <input type="text" v-model="dataObj.text" />--%>
        <button v-on:click="dialog" >Open</button>
        <open-modal v-if="show" v-bind:back="callBack" v-bind:close="closeCallBack"></open-modal>

    </div>
    <script type="text/javascript"> 
        // jsファイルで使用する定数の定義
        const POST_TYPE_DELETE = "<%=POST_TYPE_DELTE%>";
        const POST_TYPE_SELECT = "<%=POST_TYPE_SELECT%>";
        const POST_TYPE_INIT = "<%=POST_TYPE_INIT%>";

        const URL = "Default.aspx";
    </script>
    <script type="text/javascript" src="masterlist.js"></script>
 </body>

</html>

