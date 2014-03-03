<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoundAbout.aspx.cs" Inherits="SkySound.SoundAbout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />

<link rel="stylesheet" type="text/css" href="images/style.css" />
<title>天籁网站-Sounds of Nature</title>
</head>
<body>
<form id="form1" runat=server>
	<div id="bg">
		<div id="sadrzaj">
			<div id="zaglavlje">
			
				<div id="title">
					<a href="#">Sounds of Nature</a> 
				</div>				
				
					搜索: <asp:DropDownList ID="DropDownList" runat="server">
                   <asp:ListItem Value="category">类别</asp:ListItem>
                    <asp:ListItem Value="name">名称</asp:ListItem> </asp:DropDownList>
               <asp:TextBox ID="TBSearch" runat="server"></asp:TextBox>
                <asp:Button ID="BSearch" runat="server" Text="搜索" onclick="BSearch_Click" />
			</div>

			<div id="navigacija">
				<ul>
					<li><a href="Default.aspx">网站主页</a></li>
					<li><a href="SoundAbout.aspx">关于天籁</a></li>
					<li><a href="SoundSongList.aspx">天籁乐库</a></li>
					<li><a href="SoundRegister.aspx">会员注册</a></li>
					<li><a href="SoundAdmin/Login.aspx">后台管理</a></li>
				</ul>
	
				<div class="lijevo">
					<h3>最新用户</h3>
					<asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>                                
                                <%# Eval("name")%> &nbsp;&nbsp;                           
                               
                                
                        </ItemTemplate>
                        </asp:Repeater>
					
					<%--<div id="infobox">
					Just some small text describing the article
					</div>--%>
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			

			<div class="lijeva_rubrika">
			<h3>关于天籁</h3>
				<pre>
                欢迎来到天籁网站，在这里，你可以选择播放自己喜欢的歌曲~
                </pre>
			</div>
			<div id="downbox">
		 
			</div>
			
			<div id="footer">
			    Copyright © 2011 Designed by 类菌体</div>
		</div>
	</div>
    </form>
</body>
</html>
