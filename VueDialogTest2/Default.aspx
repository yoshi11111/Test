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

        <div>
            <%--<input type="text" v-model="title">--%>
            <button v-on:click="doAdd('1')">ダイアログなしPOST</button>
            <button v-on:click="doAdd('2')">ダイアログPOST</button>
            <button v-on:click="doAdd('3')">削除確認</button>

            <%-- <ul>
                <li v-for="(todo, i) in todos" v-bind:key="i">
                    <span class="todo-title" v-bind:class="{'done': todo.done}">{{todo.title}}</span>
                    <button v-on:click="doMarkAsDone(i)" v-if="!todo.done">done</button>
                </li>
            </ul>--%>
            <open-modal v-bind:call-back="callBack" v-bind:msg="msg"  v-on:click-no="close" v-bind:arg="arg" v-bind:show="isShowConfirmModal"></open-modal>
        </div>

        <%-- 以下はファイルポストテスト --%>

        <%-- 方法１ --%>
        <%--<button v-on:click="upload">button</button>--%>

        <%-- 方法２ --%>
        <%--   <input id="ipt_file" type="file" />
        <a href='#' onclick="UploadFile();" data-role='button'>Upload</a>--%>



        <%-- 通常POST --%>
        <%--        <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
            <p>送信するファイルを指定して、［送信］ボタンを押してください。</p>
            <p>
                <input type="file" name="userfile" id="userfile">
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="送信" />
            </p>
        </form>--%>
    </div>






    <script type="text/javascript">

        const app = new Vue({
            el: '#app',
            data: {
                title: '',
                todos: [],
                isShowConfirmModal: false,
                callBack: null,
              //  postType: 0,
                msg: '',
                arg:''
            },
            methods: {
                doAdd: function (type) {
                 //   this.postType = type;
                    this.arg = type;
                    if (type == 1) {
                        this.cons(type);
                    }
                    if (type == 2) {
                        this.callBack = this.cons;
                        this.msg = '更新しますか？';
                        this.isShowConfirmModal = true;
                    }
                    if (type == 3) {
                        this.callBack = this.doubleChk;
                        this.msg = '削除しますか？';
                        this.isShowConfirmModal = true;
                    }
                },

                doubleChk: function (arg) {
                    this.callBack = this.cons;
                    this.msg = '本当に？';
                    this.isShowConfirmModal = true;
                },

                cons: function (arg) {
                    this.isShowConfirmModal = false;
                    console.log(arg);
                },
                close: function () {
                    this.isShowConfirmModal = false;
                }
            }
        });
        //        async doAdd() {
        //            console.log('_1');
        //if (!await this.askConfirm()) return
        //this.todos.unshift({
        //    title: this.title,
        //    done: false,
        //})
        //this.title = ''
        //console.log('_2');

        //},
        //async doMarkAsDone(todoIndex) {
        //    console.log('&1');

        //    if (!await this.askConfirm()) return
        //    this.todos = this.todos.map((todo, index) => ({
        //        ...todo,
        //            done: index === todoIndex ? true : todo.done,
        //            }))
        //            console.log('&2');

        //},
        //askConfirm() {
        //    this.isShowConfirmModal = true
        //    return new Promise(resolve =>
        //        this.$once('answerdConfirm', confirmValue => {
        //            this.isShowConfirmModal = false
        //            resolve(confirmValue)
        //    })
        //            )
        //},
        //},
        //data: {
        //    showContent: false,
        //    senddata: {
        //        file: 'test'
        //    }
        //},
        //methods: {
        //    openModal: function () {
        //        this.showContent = true
        //    },
        //    closeModal: function () {
        //        this.showContent = false
        //    },



        //    selectedFile: function (e) {
        //        // 選択された File の情報を保存しておく
        //        e.preventDefault();
        //        let files = e.target.files;
        //        this.file = files[0];


        //    },
        //    upload: function () {

        //        var form = $('#Form1').get()[0];
        //        var params = new FormData(form);
        //        const options = {
        //            headers: { 'content-type': 'multipart/form-data' }
        //        };

        //        axios.post('Default.aspx/Test', params, options)
        //            .then(function (response) {
        //                // 成功時
        //            })
        //            .catch(function (error) {
        //                // エラー時
        //            });
        //    },
        //    jsonTest: function () {

        //        const options = {
        //            headers: { 'Content-Type': 'application/json;charset=utf-8' }
        //        };

        //        axios.post('Default.aspx/Test', params, options)
        //            .then(res => {
        //                console.log(res.headers);
        //            })
        //            .catch(err => {
        //                // 略
        //            });
        //    }
        //}

    </script>
</body>
</html>
