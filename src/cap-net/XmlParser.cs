﻿using System;
using System.Xml;

namespace CAP
{
    public class XmlParser
    {
        public static Alert Parse(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            var alert = ParseInternal(document);
            return alert;
        }

        public static Alert Parse(XmlDocument xml)
        {
            var alert = ParseInternal(xml);
            return alert;
        }

        private static Alert ParseInternal(XmlDocument document)
        {
            var alert = new Alert();

            XmlNodeList elements = document.GetElementsByTagName("alert", "urn:oasis:names:tc:emergency:cap:1.1");

            foreach (XmlNode element in elements)
            {
                foreach (XmlNode alertNode in element.ChildNodes)
                {
                    switch (alertNode.Name)
                    {
                        case "identifier":
                            alert.Identifier = alertNode.InnerText;
                            break;
                        case "sender":
                            alert.Sender = alertNode.InnerText;
                            break;
                        case "sent":
                            alert.Sent = DateTime.Parse(alertNode.InnerText);
                            break;
                        case "status":
                            alert.Status = alertNode.InnerText;
                            break;
                        case "msgType":
                            alert.MessageType = MessageType.Alert;
                            break;
                        case "source":
                            alert.Source = alertNode.InnerText;
                            break;
                        case "scope":
                            alert.Scope = Scope.Public;
                            break;
                        case "restriction":
                            alert.Restriction = alertNode.InnerText;
                            break;
                        case "addresses":
                            alert.Addresses = alertNode.InnerText;
                            break;
                        case "code":
                            alert.Code = alertNode.InnerText;
                            break;
                        case "note":
                            alert.Note = alertNode.InnerText;
                            break;
                        case "references":
                            alert.References = alertNode.InnerText;
                            break;
                        case "incidents":
                            alert.Incidents = alertNode.InnerText;
                            break;
                        case "info":
                            var info = new Info();
                            foreach (XmlNode infoNode in alertNode.ChildNodes)
                            {
                                switch (infoNode.Name)
                                {
                                    case "language":
                                        info.Language = infoNode.InnerText;
                                        break;
                                    case "category":
                                        info.Category = infoNode.InnerText;
                                        break;
                                    case "event":
                                        info.Event = infoNode.InnerText;
                                        break;
                                    case "responseType":
                                        info.ResponseType = infoNode.InnerText;
                                        break;
                                    case "urgency":
                                        info.Urgency = infoNode.InnerText;
                                        break;
                                    case "severity":
                                        info.Severity = infoNode.InnerText;
                                        break;
                                    case "certainty":
                                        info.Certainty = infoNode.InnerText;
                                        break;
                                    case "audience":
                                        info.Audience = infoNode.InnerText;
                                        break;
                                    case "eventCode":
                                        info.EventCode = infoNode.InnerText;
                                        break;
                                    case "effective":
                                        info.Effective = DateTime.Parse(infoNode.InnerText);
                                        break;
                                    case "onset":
                                        info.Onset = DateTime.Parse(infoNode.InnerText);
                                        break;
                                    case "expires":
                                        info.Expires = DateTime.Parse(infoNode.InnerText);
                                        break;
                                    case "senderName":
                                        info.SenderName = infoNode.InnerText;
                                        break;
                                    case "headline":
                                        info.Headline = infoNode.InnerText;
                                        break;
                                    case "description":
                                        info.Description = infoNode.InnerText;
                                        break;
                                    case "instruction":
                                        info.Instruction = infoNode.InnerText;
                                        break;
                                    case "web":
                                        info.Web = infoNode.InnerText;
                                        break;
                                    case "contact":
                                        info.Contact = infoNode.InnerText;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            alert.Info.Add(info);
                            break;
                        default:
                            break;
                    }
                }
            }

            return alert;
        }
    }
}
