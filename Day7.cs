using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day7
    {
        //readonly string testInput = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a\r\n$ ls\r\ndir e\r\n29116 f\r\n2557 g\r\n62596 h.lst\r\n$ cd e\r\n$ ls\r\n584 i\r\n$ cd ..\r\n$ cd ..\r\n$ cd d\r\n$ ls\r\n4060174 j\r\n8033020 d.log\r\n5626152 d.ext\r\n7214296 k";
        readonly string puzzleInput = "$ cd /\r\n$ ls\r\n246027 gldg.jrd\r\ndir qffvbf\r\ndir qjjgh\r\ndir vpjqpqfm\r\n$ cd qffvbf\r\n$ ls\r\ndir dcqf\r\ndir grcj\r\ndir hwllqcd\r\n76103 jrhp.hgg\r\n253696 nscv.wvb\r\ndir stnrzs\r\ndir vzgpfd\r\n$ cd dcqf\r\n$ ls\r\ndir gcjmpnsl\r\n$ cd gcjmpnsl\r\n$ ls\r\n198360 gldg.jrd\r\n$ cd ..\r\n$ cd ..\r\n$ cd grcj\r\n$ ls\r\n56512 grgtnhn.zdn\r\n$ cd ..\r\n$ cd hwllqcd\r\n$ ls\r\n100505 frzf.mzc\r\n209030 gldg.jrd\r\n9330 jjtjjlsr.dnl\r\n191034 mfmps.vjt\r\n82405 nscv.wvb\r\n$ cd ..\r\n$ cd stnrzs\r\n$ ls\r\ndir gmtmfpmb\r\ndir jrhp\r\ndir rhf\r\ndir wzjtd\r\n$ cd gmtmfpmb\r\n$ ls\r\n279472 hswhjhmj\r\n81339 rsgsrn\r\n$ cd ..\r\n$ cd jrhp\r\n$ ls\r\ndir fpmnp\r\n99771 grcj.scb\r\ndir hjglg\r\ndir hwvzv\r\n$ cd fpmnp\r\n$ ls\r\n33215 grcj.tcj\r\n$ cd ..\r\n$ cd hjglg\r\n$ ls\r\n206893 tctfwpf.jhv\r\n$ cd ..\r\n$ cd hwvzv\r\n$ ls\r\ndir mfmps\r\n$ cd mfmps\r\n$ ls\r\n46252 rjrmbqwr.wbj\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd rhf\r\n$ ls\r\n222859 dcgvw\r\n41140 grcj.qzh\r\ndir zcjh\r\n217515 zgqjbf\r\n$ cd zcjh\r\n$ ls\r\n92243 prqhbzl.hls\r\n$ cd ..\r\n$ cd ..\r\n$ cd wzjtd\r\n$ ls\r\ndir bnjj\r\ndir dhhpf\r\ndir grcj\r\ndir jqmnp\r\n16602 mfmps.dht\r\ndir mrgh\r\n112236 rsgsrn\r\ndir wqwwwfd\r\n243851 zgqjbf.bjh\r\n$ cd bnjj\r\n$ ls\r\n158778 zjdvggcz.fhr\r\n$ cd ..\r\n$ cd dhhpf\r\n$ ls\r\n228680 gldg.jrd\r\n18523 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd grcj\r\n$ ls\r\ndir bcbspw\r\ndir mpq\r\ndir pjzw\r\n$ cd bcbspw\r\n$ ls\r\n5449 rsgsrn\r\n$ cd ..\r\n$ cd mpq\r\n$ ls\r\n135338 mfmps\r\n$ cd ..\r\n$ cd pjzw\r\n$ ls\r\ndir cpffwn\r\n$ cd cpffwn\r\n$ ls\r\n131835 rnwqngz\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd jqmnp\r\n$ ls\r\n281939 nscv.wvb\r\n103834 rsgsrn\r\n34528 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd mrgh\r\n$ ls\r\ndir grcj\r\n$ cd grcj\r\n$ ls\r\n211470 bbzm.sbq\r\n$ cd ..\r\n$ cd ..\r\n$ cd wqwwwfd\r\n$ ls\r\n59532 blfr.lqh\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\ndir grcj\r\ndir lvhfqr\r\ndir zgvjpnf\r\n$ cd grcj\r\n$ ls\r\n160936 jbfsbsnn.sgj\r\ndir mfmps\r\ndir mfqjssr\r\ndir vzgpfd\r\ndir zgqjbf\r\n$ cd mfmps\r\n$ ls\r\n176441 dcgvw\r\n9961 grcj.sdl\r\ndir mfmps\r\n181303 nscv.wvb\r\n273550 zfjhqtp\r\n$ cd mfmps\r\n$ ls\r\ndir ndqjhlhp\r\n$ cd ndqjhlhp\r\n$ ls\r\n43593 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd mfqjssr\r\n$ ls\r\n137211 gldg.jrd\r\n254301 grcj.rgv\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\ndir hqnfwtj\r\ndir mtqzh\r\n215717 thd.cgt\r\ndir vgtvctd\r\ndir vzgpfd\r\n64282 zgqjbf\r\n$ cd hqnfwtj\r\n$ ls\r\n155738 cjpqzq\r\n128579 cnsm.mdt\r\n150972 fpmjd\r\n54851 rsgsrn\r\n$ cd ..\r\n$ cd mtqzh\r\n$ ls\r\n288824 bjnhtwg\r\n209838 gldg.jrd\r\n87464 jgdhm.wrb\r\ndir nbnzfc\r\n$ cd nbnzfc\r\n$ ls\r\ndir rtrbhtb\r\n267378 wcfpqqp.tcf\r\n152165 wsww.gdd\r\n$ cd rtrbhtb\r\n$ ls\r\n264454 dcgvw\r\n221078 jrhp.fsj\r\ndir sgm\r\n$ cd sgm\r\n$ ls\r\ndir tzzfc\r\n$ cd tzzfc\r\n$ ls\r\n207888 cdmht.jjn\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd vgtvctd\r\n$ ls\r\ndir dtm\r\ndir gghjmgqs\r\ndir grcj\r\ndir lcpmlcpn\r\n57113 njpnzq.phl\r\n279566 rsgsrn\r\n59404 tzl\r\n221164 vcpzw.qsh\r\n$ cd dtm\r\n$ ls\r\ndir pmsvz\r\ndir zdzv\r\n$ cd pmsvz\r\n$ ls\r\ndir qctt\r\n$ cd qctt\r\n$ ls\r\n285640 wzh.hwv\r\n$ cd ..\r\n$ cd ..\r\n$ cd zdzv\r\n$ ls\r\n178732 fdvth.rvs\r\ndir jjslblcb\r\ndir tvq\r\ndir zgqjbf\r\n$ cd jjslblcb\r\n$ ls\r\ndir grcj\r\n$ cd grcj\r\n$ ls\r\n186485 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd ..\r\n$ cd tvq\r\n$ ls\r\n48035 jrhp.qnf\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n276537 gldg.jrd\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd gghjmgqs\r\n$ ls\r\n238068 qqczbf\r\n$ cd ..\r\n$ cd grcj\r\n$ ls\r\ndir qnn\r\n$ cd qnn\r\n$ ls\r\n117284 jmst.mld\r\n$ cd ..\r\n$ cd ..\r\n$ cd lcpmlcpn\r\n$ ls\r\ndir cbzpzsj\r\n53036 frzslwl.qgd\r\n82430 grcj\r\n273768 pvzslpsn.ztw\r\n67092 rsgsrn\r\n$ cd cbzpzsj\r\n$ ls\r\n36456 gldg.jrd\r\n95656 mfmps.cfl\r\n2578 qpl.jhn\r\n225756 sqt.njp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\n266582 cgvcwrfn.jjq\r\n230770 dcgvw\r\n266361 gqqcqtp.hvq\r\ndir lnn\r\n86659 pzft.smj\r\n180519 qfszrvm.gnq\r\ndir rwrt\r\ndir thrthq\r\ndir zgqjbf\r\n$ cd lnn\r\n$ ls\r\n13294 dqqvbcf\r\n268614 mczrlg.vmz\r\ndir wqccmlvq\r\ndir zgqjbf\r\n$ cd wqccmlvq\r\n$ ls\r\ndir grcj\r\n$ cd grcj\r\n$ ls\r\n55504 gldg.jrd\r\n6925 jbqzth.rcj\r\n168475 jqzmc.sfm\r\n$ cd ..\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n172255 nptpqjd.hzz\r\n$ cd ..\r\n$ cd ..\r\n$ cd rwrt\r\n$ ls\r\n78039 jrhp.cmf\r\n237632 mfmps\r\n$ cd ..\r\n$ cd thrthq\r\n$ ls\r\n122514 jrhp.fcj\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\ndir dpbnq\r\ndir mfmps\r\ndir rbnzhhn\r\n$ cd dpbnq\r\n$ ls\r\ndir vzgpfd\r\n$ cd vzgpfd\r\n$ ls\r\n278947 bhdtwf\r\n$ cd ..\r\n$ cd ..\r\n$ cd mfmps\r\n$ ls\r\n118315 mfmps.lbq\r\n$ cd ..\r\n$ cd rbnzhhn\r\n$ ls\r\n96386 svwv.ldj\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n196735 cmrdgjl.hbd\r\n$ cd ..\r\n$ cd ..\r\n$ cd lvhfqr\r\n$ ls\r\ndir njzv\r\ndir sgwzscp\r\ndir zgqjbf\r\n$ cd njzv\r\n$ ls\r\n60680 bmqh.snz\r\n129703 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd sgwzscp\r\n$ ls\r\ndir rnjrj\r\n1799 vzgpfd\r\n37203 zgqjbf.jwf\r\n25768 zjh\r\n$ cd rnjrj\r\n$ ls\r\n242223 blrzc\r\n63563 plb.dlq\r\n$ cd ..\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n91151 cmn.gcw\r\n235818 llsnw.phb\r\n$ cd ..\r\n$ cd ..\r\n$ cd zgvjpnf\r\n$ ls\r\n158932 nscv.wvb\r\n110912 wzm\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd qjjgh\r\n$ ls\r\ndir cwslqsb\r\n34405 dcgvw\r\ndir fvmmd\r\ndir jrhp\r\ndir vflhljrl\r\n239915 vzgpfd\r\n$ cd cwslqsb\r\n$ ls\r\n49934 mqzfncgb.jbf\r\n$ cd ..\r\n$ cd fvmmd\r\n$ ls\r\ndir grcj\r\ndir jrhp\r\ndir sqmbncp\r\ndir vzgpfd\r\n$ cd grcj\r\n$ ls\r\n32276 bjgc\r\n211068 mfmps\r\n$ cd ..\r\n$ cd jrhp\r\n$ ls\r\n218633 wpqh.jfl\r\n$ cd ..\r\n$ cd sqmbncp\r\n$ ls\r\n137187 tzqqm.jqr\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\n258286 hqg.qzn\r\ndir mvqgb\r\n236455 vqdtns\r\n255724 wrnhw.mzf\r\n192529 zgqjbf.zzb\r\n$ cd mvqgb\r\n$ ls\r\ndir vzgpfd\r\n$ cd vzgpfd\r\n$ ls\r\n200955 grcj.wwl\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd jrhp\r\n$ ls\r\n86368 dcgvw\r\n16512 vzgpfd\r\n245341 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd vflhljrl\r\n$ ls\r\n82670 gldg.jrd\r\n228251 nscv.wvb\r\n$ cd ..\r\n$ cd ..\r\n$ cd vpjqpqfm\r\n$ ls\r\n246705 gfff\r\ndir grcj\r\ndir hjdwrt\r\ndir mfmps\r\ndir plrrsmph\r\ndir rgqtzc\r\n175555 rsgsrn\r\n142983 wjpbr.hdr\r\ndir zlv\r\n$ cd grcj\r\n$ ls\r\ndir grcj\r\ndir mdvcmm\r\n285341 mfmps\r\n89089 nscv.wvb\r\n$ cd grcj\r\n$ ls\r\ndir fcdz\r\ndir fswpmd\r\ndir gvjjjp\r\ndir jrhp\r\n$ cd fcdz\r\n$ ls\r\ndir dpwvm\r\ndir rmmw\r\n$ cd dpwvm\r\n$ ls\r\ndir chjbpb\r\n118852 dcgvw\r\ndir dsc\r\n7271 fclhnmz.cbp\r\n$ cd chjbpb\r\n$ ls\r\n41211 pzr\r\n$ cd ..\r\n$ cd dsc\r\n$ ls\r\n217960 nscv.wvb\r\n$ cd ..\r\n$ cd ..\r\n$ cd rmmw\r\n$ ls\r\ndir cqzvcv\r\ndir hld\r\n99687 jrhp.nnb\r\ndir pfvthfw\r\n97451 qjmfdjwz.phc\r\n$ cd cqzvcv\r\n$ ls\r\ndir zgqjbf\r\n$ cd zgqjbf\r\n$ ls\r\n204153 nscv.wvb\r\n$ cd ..\r\n$ cd ..\r\n$ cd hld\r\n$ ls\r\n113905 pwqs\r\n244609 wfsgg.jgp\r\n$ cd ..\r\n$ cd pfvthfw\r\n$ ls\r\ndir grcj\r\n$ cd grcj\r\n$ ls\r\n207441 jrhp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd fswpmd\r\n$ ls\r\n99446 gldg.jrd\r\n$ cd ..\r\n$ cd gvjjjp\r\n$ ls\r\ndir pvzz\r\n279071 wdmm.vjv\r\n$ cd pvzz\r\n$ ls\r\n196937 nqfzj\r\n273491 nscv.wvb\r\ndir qthbl\r\n$ cd qthbl\r\n$ ls\r\n204553 dcgvw\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd jrhp\r\n$ ls\r\n175979 fct.dcg\r\n$ cd ..\r\n$ cd ..\r\n$ cd mdvcmm\r\n$ ls\r\ndir crscnnh\r\n109461 dcdtm.tvp\r\n279544 ftzvrpcw.pff\r\n124059 nnc\r\n274104 nscv.wvb\r\ndir ssvd\r\ndir zvvhlw\r\n$ cd crscnnh\r\n$ ls\r\ndir tzbjl\r\n$ cd tzbjl\r\n$ ls\r\n112219 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd ..\r\n$ cd ssvd\r\n$ ls\r\n227906 bsqhzw\r\n$ cd ..\r\n$ cd zvvhlw\r\n$ ls\r\n166628 gldg.jrd\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd hjdwrt\r\n$ ls\r\n59644 jrhp.fjj\r\ndir rpsrm\r\n221706 rsgsrn\r\ndir rzn\r\n14344 tvlmvr.flr\r\ndir vlbrnq\r\ndir vrcns\r\n39113 wcfpqqp.tcf\r\ndir zhwm\r\n$ cd rpsrm\r\n$ ls\r\n282957 wmpnpjzd\r\n$ cd ..\r\n$ cd rzn\r\n$ ls\r\n142973 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd vlbrnq\r\n$ ls\r\n79661 ccznjt.fqr\r\n$ cd ..\r\n$ cd vrcns\r\n$ ls\r\n262645 dcnnnhn.vhg\r\n$ cd ..\r\n$ cd zhwm\r\n$ ls\r\ndir glgs\r\ndir grcj\r\ndir jrhp\r\n$ cd glgs\r\n$ ls\r\n282326 tcw.qnb\r\n$ cd ..\r\n$ cd grcj\r\n$ ls\r\n43293 qnqb.jqg\r\n$ cd ..\r\n$ cd jrhp\r\n$ ls\r\n197274 pgf.ltc\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd mfmps\r\n$ ls\r\ndir dcm\r\n47902 mrcn.wtb\r\n8444 mzdgdh.ctn\r\n$ cd dcm\r\n$ ls\r\n72397 mnrvqg.vmm\r\n$ cd ..\r\n$ cd ..\r\n$ cd plrrsmph\r\n$ ls\r\n216816 gldg.jrd\r\n148190 jzbswh\r\n120319 wcfpqqp.tcf\r\ndir zgqjbf\r\n$ cd zgqjbf\r\n$ ls\r\ndir cfdr\r\ndir hdsnc\r\n$ cd cfdr\r\n$ ls\r\n34272 bzctmbvt.qzr\r\n$ cd ..\r\n$ cd hdsnc\r\n$ ls\r\n43772 ccds.vlz\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd rgqtzc\r\n$ ls\r\ndir dblznh\r\ndir lfpdqm\r\ndir lmnmthm\r\ndir mfmps\r\ndir pcplzs\r\ndir pvfbjm\r\ndir rnl\r\ndir wqgp\r\ndir zgqjbf\r\n$ cd dblznh\r\n$ ls\r\n65168 tdv.mwq\r\n$ cd ..\r\n$ cd lfpdqm\r\n$ ls\r\ndir cgvnspv\r\ndir dthhvrln\r\ndir jrhp\r\ndir vzgpfd\r\n$ cd cgvnspv\r\n$ ls\r\ndir qnmg\r\n$ cd qnmg\r\n$ ls\r\ndir grcj\r\n70937 jbvrp.psn\r\n207093 vfgds.tjv\r\n282330 vtlzgq.dfd\r\n251235 zbvgc.whr\r\n$ cd grcj\r\n$ ls\r\ndir pbn\r\n$ cd pbn\r\n$ ls\r\n22094 dqt.dtv\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd dthhvrln\r\n$ ls\r\n206159 wvvczgd.wzs\r\n$ cd ..\r\n$ cd jrhp\r\n$ ls\r\ndir bqf\r\n5738 rgpwf\r\ndir zjhw\r\n$ cd bqf\r\n$ ls\r\ndir clgjfn\r\n58416 fcr\r\n216467 mcdqnw.prv\r\n288978 zthdgfhl.lqq\r\n$ cd clgjfn\r\n$ ls\r\n274929 lwnpggm.mfp\r\n$ cd ..\r\n$ cd ..\r\n$ cd zjhw\r\n$ ls\r\ndir cbwrrzwh\r\ndir fdz\r\ndir grcj\r\n219439 grcj.szv\r\n285756 mfmps\r\n113288 mmg.cpr\r\n236059 nmq\r\ndir pbnfdq\r\n74013 tvmswr\r\ndir zgqjbf\r\n$ cd cbwrrzwh\r\n$ ls\r\n223425 zgqjbf.ffm\r\n$ cd ..\r\n$ cd fdz\r\n$ ls\r\ndir wbtzsr\r\n$ cd wbtzsr\r\n$ ls\r\n257781 hzf\r\n$ cd ..\r\n$ cd ..\r\n$ cd grcj\r\n$ ls\r\n58266 dcgvw\r\ndir rhncgdll\r\ndir vzgpfd\r\n12503 zgv.ndt\r\n$ cd rhncgdll\r\n$ ls\r\ndir vnmbhbhc\r\n$ cd vnmbhbhc\r\n$ ls\r\n10019 lfcggd.ccw\r\n$ cd ..\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\n134965 zdsp.tzg\r\n78684 zmjjvf.glv\r\n$ cd ..\r\n$ cd ..\r\n$ cd pbnfdq\r\n$ ls\r\n173729 frqdqhw\r\ndir fvjc\r\n41055 svwd\r\n106934 tngzpl.lml\r\ndir zqhjjjd\r\n$ cd fvjc\r\n$ ls\r\n88907 pcvcpptp.dsr\r\n133102 tszsbtjp.lfl\r\n$ cd ..\r\n$ cd zqhjjjd\r\n$ ls\r\n61260 mpdlcjl\r\ndir wfw\r\n$ cd wfw\r\n$ ls\r\ndir jrhp\r\ndir lwg\r\n226393 rndnc\r\ndir zhrtj\r\n$ cd jrhp\r\n$ ls\r\n276912 dcgvw\r\ndir pwrjq\r\ndir zmnv\r\n$ cd pwrjq\r\n$ ls\r\n198180 vclfmjf.tfp\r\n$ cd ..\r\n$ cd zmnv\r\n$ ls\r\n84228 mfmps.wzw\r\n$ cd ..\r\n$ cd ..\r\n$ cd lwg\r\n$ ls\r\ndir jrhp\r\n50562 lwcfwjh.dtm\r\n145174 vnl\r\n$ cd jrhp\r\n$ ls\r\n86877 dcgvw\r\n$ cd ..\r\n$ cd ..\r\n$ cd zhrtj\r\n$ ls\r\n284728 rsgsrn\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n202268 zqpvm\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\n138188 djqqfrbn.cps\r\n$ cd ..\r\n$ cd ..\r\n$ cd lmnmthm\r\n$ ls\r\n2715 fqdm.bvm\r\n37482 jdsn.zpr\r\n255467 nscv.wvb\r\n175914 stvscbg\r\n$ cd ..\r\n$ cd mfmps\r\n$ ls\r\n288712 gldg.jrd\r\n182389 jrhp\r\ndir lvjg\r\n41815 nscv.wvb\r\ndir vzgpfd\r\ndir zgqjbf\r\ndir zvpnq\r\n$ cd lvjg\r\n$ ls\r\n184529 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\n265556 hjqng.glq\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\ndir dqmbmlrf\r\ndir grcj\r\ndir hlsr\r\n$ cd dqmbmlrf\r\n$ ls\r\ndir bdvhvwct\r\n254123 bzhhm.rqp\r\n172950 fgqbj.bcb\r\n7417 fjfq.qbv\r\n188707 hfvvlvqg.sqh\r\n78273 ppljtfjr.hpm\r\ndir zgqjbf\r\n$ cd bdvhvwct\r\n$ ls\r\n76840 gldg.jrd\r\ndir grcj\r\n$ cd grcj\r\n$ ls\r\ndir vzgpfd\r\n$ cd vzgpfd\r\n$ ls\r\n73163 mfmps.tnr\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n62316 lpzsww\r\n$ cd ..\r\n$ cd ..\r\n$ cd grcj\r\n$ ls\r\n160721 bwvgdqdr\r\n$ cd ..\r\n$ cd hlsr\r\n$ ls\r\n214688 vzgpfd\r\n$ cd ..\r\n$ cd ..\r\n$ cd zvpnq\r\n$ ls\r\n34940 gjbzp.nqg\r\n165326 mfmps.gfp\r\ndir rwddqchj\r\ndir ssw\r\ndir zgqjbf\r\n$ cd rwddqchj\r\n$ ls\r\ndir gnsndln\r\n$ cd gnsndln\r\n$ ls\r\n223320 zgqjbf.wlm\r\n$ cd ..\r\n$ cd ..\r\n$ cd ssw\r\n$ ls\r\ndir grcj\r\n$ cd grcj\r\n$ ls\r\n251146 gldg.jrd\r\n$ cd ..\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n45732 vzgpfd.nbz\r\n86126 zdnv.sss\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pcplzs\r\n$ ls\r\n90287 grcj\r\n99213 rsgsrn\r\ndir shmsp\r\n156357 tgc.lzp\r\ndir thbznt\r\ndir vtqlszrs\r\ndir vzgpfd\r\n$ cd shmsp\r\n$ ls\r\ndir jrhp\r\n$ cd jrhp\r\n$ ls\r\n132784 tmlntm\r\n$ cd ..\r\n$ cd ..\r\n$ cd thbznt\r\n$ ls\r\n190697 mdj.lll\r\n270626 wcfpqqp.tcf\r\n$ cd ..\r\n$ cd vtqlszrs\r\n$ ls\r\n44292 dcgvw\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\n13921 hccgnjqh.cdl\r\ndir jrhp\r\n23850 jvq\r\n113952 mfmps\r\ndir ppdfjqbr\r\ndir vdpvzhrs\r\n190631 vzgpfd\r\n128060 wclfwhv.chh\r\ndir wghzqb\r\n$ cd jrhp\r\n$ ls\r\n237755 bgbmnpq\r\n19551 dcgvw\r\n$ cd ..\r\n$ cd ppdfjqbr\r\n$ ls\r\n1458 dcgvw\r\n563 gldg.jrd\r\n155487 glhjmpm.sjt\r\ndir vthf\r\ndir vzgpfd\r\n81314 zgqjbf.scm\r\n$ cd vthf\r\n$ ls\r\n205316 vzgpfd.qlg\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\n46597 mfmps.zsq\r\n$ cd ..\r\n$ cd ..\r\n$ cd vdpvzhrs\r\n$ ls\r\n13302 vcwrr.jvb\r\n$ cd ..\r\n$ cd wghzqb\r\n$ ls\r\ndir grcj\r\ndir hbngsg\r\n112293 jzvh.pvf\r\n282888 smrq.lvp\r\n$ cd grcj\r\n$ ls\r\n258764 nscv.wvb\r\n230478 qpqgf\r\n$ cd ..\r\n$ cd hbngsg\r\n$ ls\r\n101699 bzwnwz.tgj\r\n144196 hwjrgtt.pdm\r\ndir mthnljv\r\n$ cd mthnljv\r\n$ ls\r\n1397 jrhp.rvp\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd pvfbjm\r\n$ ls\r\n251602 nscv.wvb\r\n$ cd ..\r\n$ cd rnl\r\n$ ls\r\n233954 dqlncnds.dfn\r\ndir nswpmqdd\r\n$ cd nswpmqdd\r\n$ ls\r\n261883 rtpbgm.gbf\r\n$ cd ..\r\n$ cd ..\r\n$ cd wqgp\r\n$ ls\r\n23813 pdfcfc\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n15126 bvlbrq.pdj\r\ndir jnjqhzh\r\ndir smrzsq\r\ndir vzgpfd\r\n$ cd jnjqhzh\r\n$ ls\r\n243919 htdqwdc.nsr\r\n254015 ppclcr.rms\r\n234928 zmjr.hnt\r\n$ cd ..\r\n$ cd smrzsq\r\n$ ls\r\ndir ljvbmm\r\n$ cd ljvbmm\r\n$ ls\r\n235241 jmcbrbdl.ccr\r\n$ cd ..\r\n$ cd ..\r\n$ cd vzgpfd\r\n$ ls\r\ndir bhwd\r\n38855 dcgvw\r\ndir hdcqm\r\ndir swcvhtmp\r\ndir zgqjbf\r\n118104 zhtlsdb.ncw\r\n$ cd bhwd\r\n$ ls\r\n122018 gldg.jrd\r\ndir lmjr\r\ndir mfmps\r\n$ cd lmjr\r\n$ ls\r\n40588 dcgvw\r\n$ cd ..\r\n$ cd mfmps\r\n$ ls\r\ndir grcj\r\n$ cd grcj\r\n$ ls\r\n165840 zwbvbfj\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd hdcqm\r\n$ ls\r\n156543 qfb.vhv\r\n$ cd ..\r\n$ cd swcvhtmp\r\n$ ls\r\n227964 rrfnsqw.rvh\r\n$ cd ..\r\n$ cd zgqjbf\r\n$ ls\r\n94269 mfmps.jsq\r\n266360 rsgsrn\r\n252761 zlz\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd ..\r\n$ cd zlv\r\n$ ls\r\n127388 nscv.wvb";

        public int Part1()
        {
            string input = puzzleInput;
            List<string> lines = new();
            
            //manually create the root directory
            DirectoryData rootDirectory = new() {Name = "/", Children = new List<DirectoryData>()};
            //start the current directory as the root. use this to track where we are in the directory
            DirectoryData currentDirectory = rootDirectory;

            //break the input into individual lines
            foreach (string line in input.Split("\r\n"))
                lines.Add(line);

            foreach (string s in lines)
            {
                //we dont care about the first line as we know the root is first
                if (s == "$ cd /")
                    continue;
                
                // if it starts cd we know we are moving to a new directory
                if (s.StartsWith("$ cd"))
                {
                    //cd .. means going up a directory so currentDirectory becomes the parent of the current directory
                    string cdValue = s[5..];
                    if (cdValue == "..")
                        currentDirectory = currentDirectory.DirectParent;

                    //else we are moving to a new directory and so create a new DirectoryData object
                    else
                    {
                        DirectoryData directory = new()
                        {
                            //name always starts after the 5th character of the line
                            Name = s[5..],

                            //direct parent is the current directory as we havent changed currentDirectory yet
                            DirectParent = currentDirectory,

                            //create an empty list for the childrent to be stored later
                            Children = new List<DirectoryData>()
                        };
                        //add the children of current directory - current directory still hasnt changed so 'directory' is a child of current directory
                        currentDirectory.Children.Add(directory);

                        //can now set current directory to the new directory
                        currentDirectory = directory;                        
                    }
                }

                //get size of each file and add it to the filesSize property of relevent directory
                if (int.TryParse(s.Split(' ')[0], out int result))                
                    currentDirectory.FilesSize += result;                
            } 
            return GetDirectorySizeForPt1(rootDirectory);
        }

        private int GetDirectorySizeForPt1(DirectoryData currentDirectory)
        {
            int totalSum = 0;

            //if the current dir has no children return its totalsize as long as it is below 100000
            if (currentDirectory.Children.Any() == false) 
                //Ternery operator. if operator is true do what os after ?, if false to what is after :
                return currentDirectory.TotalSize < 100000 ? currentDirectory.TotalSize : 0;

            //if current dir total size
            if (currentDirectory.TotalSize <= 100000)
                totalSum += currentDirectory.TotalSize;

            foreach (var d in currentDirectory.Children)            
                totalSum += GetDirectorySizeForPt1(d);
            
            return totalSum;
        }

        private int GetDirectorySizeForPt2(DirectoryData currentDirectory, int amountToDelete)
        {
            //start with root dir which is large enough
            int currentDirectorySize = currentDirectory.TotalSize;

            //if currentDir DOES NOT have children return Total size as long as it is larger than the min amount and smaller than the current (otherwise we dont care!)
            //and return as we are at the end of the directory
            if (currentDirectory.Children.Any() == false)
                return currentDirectory.TotalSize > amountToDelete && currentDirectory.TotalSize < currentDirectorySize ? currentDirectory.TotalSize : currentDirectorySize; ;

            //if current dir DOES have children - set its Total size to currentDirSize as long as it passes the checks
            if (currentDirectory.TotalSize >= amountToDelete && currentDirectory.TotalSize < currentDirectorySize)
                currentDirectorySize = currentDirectory.TotalSize;

            //as this dir does hav children we now need to loop through all the children with recursion
            foreach (var d in currentDirectory.Children)
            {
                // get the value of the smallest child directory 
                var smallestChildDir = GetDirectorySizeForPt2(d, amountToDelete);
                // if it passes the checks make it the currentDirSize
                if (smallestChildDir >= amountToDelete && smallestChildDir < currentDirectorySize)
                    currentDirectorySize = smallestChildDir;
            }
            return currentDirectorySize;
        }

        public int Part2() 
        {
            string input = puzzleInput;
            List<string> lines = new();

            //manually create the root directory
            DirectoryData rootDirectory = new() { Name = "/", Children = new List<DirectoryData>() };
            //start the current directory as the root. use this to track where we are in the directory
            DirectoryData currentDirectory = rootDirectory;

            //break the input into individual lines
            foreach (string line in input.Split("\r\n"))
                lines.Add(line);

            foreach (string s in lines)
            {
                //we dont care about the first line as we know the root is first
                if (s == "$ cd /")
                    continue;

                // if it starts cd we know we are moving to a new directory
                if (s.StartsWith("$ cd"))
                {
                    //cd .. means going up a directory so currentDirectory becomes the parent of the current directory
                    string cdValue = s[5..];
                    if (cdValue == "..")
                        currentDirectory = currentDirectory.DirectParent;

                    //else we are moving to a new directory and so create a new DirectoryData object
                    else
                    {
                        DirectoryData directory = new()
                        {
                            //name always starts after the 5th character of the line
                            Name = s[5..],

                            //direct parent is the current directory as we havent changed currentDirectory yet
                            DirectParent = currentDirectory,

                            //create an empty list for the childrent to be stored later
                            Children = new List<DirectoryData>()
                        };
                        //add the children of current directory - current directory still hasnt changed so 'directory' is a child of current directory
                        currentDirectory.Children.Add(directory);

                        //can now set current directory to the new directory
                        currentDirectory = directory;
                    }
                }

                //get size of each file and add it to the filesSize property of relevent directory
                if (int.TryParse(s.Split(' ')[0], out int result))
                    currentDirectory.FilesSize += result;
            }
            //calc min space needed to be deleted
            int totalStorage = 70000000;
            int spaceRequired = 30000000;
            int totalUsed = rootDirectory.TotalSize;
            int currentFreeSpace = totalStorage - totalUsed;
            int amountToDelete = spaceRequired - currentFreeSpace;

            int answer = GetDirectorySizeForPt2(rootDirectory, amountToDelete);
            return answer;
        }
    }

    public class DirectoryData
    {
        public string Name { get; set; }
        public List<DirectoryData> Children { get; set; }
        public int FilesSize { get; set; }
        public int TotalSize { get { return FilesSize + Children.Select(c => c.TotalSize).Sum(); } }
        public DirectoryData DirectParent { get; set; }
    }

}
