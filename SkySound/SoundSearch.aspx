﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoundSearch.aspx.cs" Inherits="SkySound.SoundSearch" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
					<h3>最新歌曲</h3>
					<table>
                    <tr>
                        <td>曲名</td>
                        <td>分类</td>
                    </tr>
                      <asp:Repeater ID="RepSelectNewS" runat="server">
                        <ItemTemplate>
                                <tr>
                                    <td><a href='SoundPlay.aspx?id=<%# Eval("id") %>' target="_blank"><%# StringTruncat(Eval("name").ToString(), 7, "...")%></a></td>
                                    <td><%# Eval("category")%></td>
                                </tr>
                        </ItemTemplate>
                        </asp:Repeater>                     
                    </table>
					
					
				</div>
			</div>

			<div id="pic">
			
					
			</div>

			

			<div class="lijeva_rubrika">
             <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
			<h3>搜索结果</h3>
				<table cellpadding="0" cellspacing="0" width=96%>
                    <tr>
                        <td><table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="style4">曲名</td>
                        <td class="style6">分类</td>
                        <td class="style5">作者</td>
                        <td class="style3">上传时间</td>
                        <td class="style7">播放次数</td>
                        <td>试听</td>
                    </tr>                 
                            
                      <asp:Repeater ID="RepSelect" runat="server">
                        <ItemTemplate>
                                <tr>
                                    <td><%# StringTruncat(Eval("name").ToString(), 7, "...")%></td>
                                    <td><%# StringTruncat(Eval("category").ToString(), 7, "...")%></td>
                                    <td><%# StringTruncat(Eval("singer").ToString(), 7, "...")%></td>
                                    <td><%# Eval("createTime")%></td>
                                    <td><%# Eval("clickCount")%></td>
                                    <td><a href='SoundPlay.aspx?id=<%# Eval("id") %>'>试听</a></td>
                                </tr>
                        </ItemTemplate>
                        </asp:Repeater>                     
                    </table>
                    <div id="emptydatas" class="replay" runat="server">
                            <p>未能找到搜索的歌曲！</p>
                    </div>
                     <webdiyer:AspNetPager ID="anp" runat="server"
                             CustomInfoHTML="总计%RecordCount%条记录，共%PageCount%页" FirstPageText="首页" 
                             LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
                             ShowCustomInfoSection="Left" CssClass="paginator" 
                             CurrentPageButtonClass="cpb" AlwaysShow="True" CustomInfoSectionWidth="" 
                             onpagechanged="anp_PageChanged">
                     </webdiyer:AspNetPager>
                </td>
                        
                    </tr>
                                           
                    </table>
                    </ContentTemplate>
        </asp:UpdatePanel>
			</div>

		
			
			<div id="footer">
			    Copyright © 2011 Designed by 类菌体</div>
		</div>
	</div>
    </form>
</body>
</html>
