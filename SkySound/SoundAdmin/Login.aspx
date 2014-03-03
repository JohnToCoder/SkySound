<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SkySound.SoundAdmin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=utf-8" />

<link rel="stylesheet" type="text/css" href="../images/style.css" />
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
					<li><a href="../Default.aspx">网站主页</a></li>
					<li><a href="../SoundAbout.aspx">关于天籁</a></li>
					<li><a href="#">天籁乐库</a></li>
					<li><a href="../SoundRegister.aspx">会员注册</a></li>
					<li><a href="../Login.aspx">后台管理</a></li>
				</ul>
	
				<div class="lijevo">
					<h3>最新用户</h3>
					<asp:Repeater ID="Repeater1" runat="server">
                     <ItemTemplate>                                
                                <%# Eval("name")%> &nbsp;&nbsp;                           
                               
                                
                        </ItemTemplate>
                        </asp:Repeater>
					
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			

			<div class="lijeva_rubrika">
			<h3>用户登录</h3>
				<table cellpadding="0" cellspacing="0" style="width: 115%">
                    <tr>
                        <td><p class="login_p">用户名：<asp:TextBox CssClass="loginTb" ID="TBName" runat="server"></asp:TextBox></p>
                <p class="login_p"> &nbsp;&nbsp; 密码：<asp:TextBox CssClass="loginTb" TextMode="Password" ID="TPWD" runat="server"></asp:TextBox></p>
                <p class="login_ps"><span>&nbsp;验证码：<asp:TextBox ID="TVitorD" CssClass="loginTb" runat="server"></asp:TextBox> </span><img class="login_image" src="ValidatImg.aspx" alt="验证码，如果不显示数字请刷新页面" /></p>
                <p class="login_p"><asp:Button ID="BLogin" runat="server" OnClick="BLogin_Click" Text="登录" Height="30px" Width="77px" /></p></td>
                        
                    </tr>
                                           
                    </table>
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
