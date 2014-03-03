<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SounduserManage.aspx.cs" Inherits="SkySound.SoundAdmin.SounduserManage" %>

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
					<li><a href="../SoundSongList.aspx">天籁乐库</a></li>
					<li><a href="../SoundRegister.aspx">会员注册</a></li>
					<li><a href="Login.aspx">后台管理</a></li>
				</ul>
	
				<div class="lijevo">
					<h3>会员信息</h3>
					<table style="width: 127px">
                      <tr>
                           <td><asp:Label ID="LBName" runat="server" Text="Label">用户名：</asp:Label></td>
                           <td><asp:Label ID="LBNames" runat="server" Text="Label"></asp:Label></td>
                     </tr> 
                     <tr>
                           <td><asp:Label ID="LBUserId" runat="server" Text="Label">昵称：</asp:Label></td>
                           <td><asp:Label ID="LBUserIds" runat="server" Text="Label"></asp:Label></td>
                     </tr> 
                     <tr>
                           <td><asp:Label ID="LBCreateTime" runat="server" Text="Label">创建时间：</asp:Label></td>
                           <td><asp:Label ID="LBCreateTimes" runat="server" Text="Label"></asp:Label></td>
                     </tr>                           
                    </table>
					<div id="infobox">
					   <ul>                           
                            <li><a href="SoundmanageSong.aspx">歌曲管理</a></li>
                            <li><a href="addSoundSong.aspx">上传歌曲</a></li>
                            <li><a href="SounduserManage.aspx">账号管理</a></li>   
                          
                       </ul>   
					</div>
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			
			<div class="lijeva_rubrika">
			<h3>账号管理</h3>
				<table cellpadding="0" cellspacing="0" style="width: 115%">
                    <tr>
                        <td><p><asp:Label ID="Label1" runat="server" Text="Label">昵称修改</asp:Label>
                    <asp:TextBox ID="TBUserId" CssClass="upTB" runat="server"></asp:TextBox>
                    <asp:Button ID="BUserId" runat="server" Text="修改" Height="30px" Width="60px" OnClientClick="return confirm('确认是否修改')" onclick="BUserId_Click" /></p>

                    <p><asp:Label ID="Label3" runat="server" Text="Label">输入旧的密码:</asp:Label>
                    <asp:TextBox ID="TBOldPw" CssClass="upTB" runat="server"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="输入旧的密码！" Text="*" ControlToValidate="TBOldPw"></asp:RequiredFieldValidator></p>
                    <p><asp:Label ID="Label4" runat="server" Text="Label">输入新的密码:</asp:Label>
                    <asp:TextBox ID="TBNewPw" CssClass="upTB" runat="server"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="输入新的密码！" Text="*" ControlToValidate="TBNewPw"></asp:RequiredFieldValidator></p>
                    <p><asp:Label ID="Label5" runat="server" Text="Label">再次输入新的密码:</asp:Label>
                    <asp:TextBox ID="TBNewPws" CssClass="upTB" runat="server"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="再次输入新的密码！" Text="*" ControlToValidate="TBNewPws"></asp:RequiredFieldValidator></p>
                    <p><asp:Button ID="BPw" runat="server" Text="修改" Height="30px" Width="60px" OnClientClick="return confirm('确认是否修改')" onclick="BPw_Click" /></td>
                        
                    </tr>
                                           
                    </table>
			</div>
			
			
			<div id="footer">
			    Copyright © 2011 Designed by 类菌体</div>
		</div>
	</div>
    </form>
</body>
</html>
