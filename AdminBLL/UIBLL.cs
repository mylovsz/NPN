using AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL = LumluxSSYDB.BLL;
using Model = LumluxSSYDB.Model;

namespace AdminBLL
{
    public class UIBLL
    {
        public static TreeData td;

        /// <summary>
        /// 增加未分组的分组
        /// </summary>
        /// <returns></returns>
        public TreeGroupInfo AddNoneTreeGroupInfo()
        {
            if(td != null)
            {
                TreeGroupInfo tgi = new TreeGroupInfo() { TreeHostInfos = new System.Collections.ObjectModel.ObservableCollection<TreeHostInfo>(), GroupInfo = new GroupInfo(new Model.tGroupInfoes() { sGUID = "", sName = "未分组" }) };
                td.TreeGroupInfos.Add(tgi);
                return tgi;
            }
            return null;
        }

        /// <summary>
        /// 获取树形相关的数据
        /// </summary>
        /// <param name="prjGUID"></param>
        /// <returns></returns>
        public TreeData GetTreeData(string prjGUID)
        {
            td = new TreeData();
            BLL.tLightGroupInfoes lgiBLL = new BLL.tLightGroupInfoes();
            BLL.tLightInfoLightGroupInfoes lilgiBLL = new BLL.tLightInfoLightGroupInfoes();
            BLL.tLightInfoes liBLL = new BLL.tLightInfoes();
            // 组信息
            List<Model.tGroupInfoes> listGI = new BLL.tGroupInfoes().GetModelListByPrjGUID(prjGUID);
            // 主机信息
            List<Model.tHostInfo> listHI = new BLL.tHostInfo().GetModelListByPrjGUID(prjGUID);

            // 增加未分组的主机
            if (listGI == null) listGI = new List<Model.tGroupInfoes>();
            if ((listHI.Count(t => t.sGroupInfoGUID.Trim() == "") > 0))
                listGI.Add(new Model.tGroupInfoes() { sName = "未分组", sGUID = "" });

            // 加入地图数据
            foreach(Model.tHostInfo mapHI in listHI)
            {
                td.ListHostInfo.Add(new HostInfo(mapHI));
                List<Model.tLightInfoes> mapListLI = liBLL.GetModelListByHostGUID(mapHI.sGUID);
                foreach(Model.tLightInfoes mapLI in mapListLI)
                {
                    td.ListLightInfo.Add(new LightInfo(mapLI, mapHI.sID_Addr));
                }
            }

            foreach(Model.tGroupInfoes gi in listGI)
            {
                // 树形数据
                TreeGroupInfo ftgi = new TreeGroupInfo();
                ftgi.GroupInfo = new GroupInfo(gi);

                List<Model.tHostInfo> flthi = listHI.Where(t => t.sGroupInfoGUID.Trim() == gi.sGUID).ToList();

                if (gi.sGUID == "" && flthi.Count == 0)
                    continue;

                foreach(Model.tHostInfo hi in flthi)
                {
                    TreeHostInfo ffthi = new TreeHostInfo();
                    ffthi.HostInfo = td.ListHostInfo.FirstOrDefault(v => v.GUID.Trim() == hi.sGUID.Trim());//new HostInfo(hi);

                    List<Model.tLightGroupInfoes> ffltlgi = lgiBLL.GetModelListByHostGUID(hi.sGUID);
                    //List<Model.tLightInfoes> ffltli = liBLL.GetModelListByHostGUID(hi.sGUID);
                    List<LightInfo> ffltli = td.ListLightInfo.Where(c=>c.HostGUID == hi.sGUID).ToList();

                    {
                        // 增加所有单灯信息
                        // if (ffltli != null && ffltli.Count > 0)
                        {
                            if(ffltlgi == null) ffltlgi = new List<Model.tLightGroupInfoes>();
                            ffltlgi.Add(new Model.tLightGroupInfoes() { sGUID = "", sName = "全部" });
                        }
                     }

                    foreach(Model.tLightGroupInfoes lgi in ffltlgi)
                    {
                        if (lgi.sGUID == "" && ffltli != null)
                        {
                            TreeLightGroupInfo tfftlgi = new TreeLightGroupInfo();
                            tfftlgi.LightGroupInfo = new LightGroupInfo(lgi);
                            foreach (LightInfo t in ffltli)
                            {
                                TreeLightInfo tmtli = new TreeLightInfo();
                                t.RoadID = hi.sID_Addr;
                                tmtli.LightInfo = t;

                                tfftlgi.TreeLightInfos.Add(tmtli);
                            }
                            ffthi.TreeLightGroupInfos.Add(tfftlgi);
                            continue;
                        }

                        List<Model.tLightInfoLightGroupInfoes> fftlilgi = lilgiBLL.GetModelListByLightGroupGUID(lgi.sGUID);
                        TreeLightGroupInfo fftlgi = new TreeLightGroupInfo();
                        fftlgi.LightGroupInfo = new LightGroupInfo(lgi);

                        foreach (Model.tLightInfoLightGroupInfoes tlilgi in fftlilgi)
                        {
                            LightInfo tli = ffltli.FirstOrDefault(t=>t.GUID == tlilgi.sLightInfoGUID);
                            if(tli != null)
                            {
                                TreeLightInfo mtli = new TreeLightInfo();
                                tli.RoadID = hi.sID_Addr;
                                mtli.LightInfo = tli;

                                fftlgi.TreeLightInfos.Add(mtli);
                            }
                        }

                        ffthi.TreeLightGroupInfos.Add(fftlgi);
                    }

                    ftgi.TreeHostInfos.Add(ffthi);
                }

                // 增加树形
                td.TreeGroupInfos.Add(ftgi);
            }

            return td;
        }
    }
}
