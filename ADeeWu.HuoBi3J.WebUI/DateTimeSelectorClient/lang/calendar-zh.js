 /*
 * Calendar EN language
 * Author: Mihai Bazon, <mihai_bazon@yahoo.com>
 */

// Encoding: any
// Distributed under the same terms as the calendar itself.

// For translators: please use UTF-8 if possible.  We strongly believe that
// Unicode is the answer to a real internationalized world.  Also please
// include your contact information in the header, as can be seen above.

// full day names
Calendar._DN = new Array
("星期一",
 "星期二",
 "星期三",
 "星期四",
 "星期五",
 "星期六",
 "星期日");

// Please note that the following array of short day names (and the same goes
// for short month names, _SMN) isn't absolutely necessary.  We give it here
// for exemplification on how one can customize the short day names, but if
// they are simply the first N letters of the full name you can simply say:
//
//   Calendar._SDN_len = N; // short day name length
//   Calendar._SMN_len = N; // short month name length
//
// If N = 3 then this is not needed either since we assume a value of 3 if not
// present, to be compatible with translation files that were written before
// this feature.

// short day names
Calendar._SDN = new Array
("星期一",
 "星期二",
 "星期三",
 "星期四",
 "星期五",
 "星期六",
 "星期日");

// First day of the week. "0" means display Sunday first, "1" means display
// Monday first, etc.
Calendar._FD = 0;

// full month names
Calendar._MN = new Array
("一月",
 "二月",
 "三月",
 "四月",
 "五月",
 "六月",
 "七月",
 "八月",
 "九月",
 "十月",
 "十一月",
 "十二月");

// short month names
Calendar._SMN = new Array
("一月",
 "二月",
 "三月",
 "四月",
 "五月",
 "六月",
 "七月",
 "八月",
 "九月",
 "十月",
 "十一月",
 "十二月");

// tooltips
Calendar._TT = {};
Calendar._TT["INFO"] = "版权帮助";

Calendar._TT["ABOUT"] =
"DHTML Date/Time Selector\n" +
"(c) dynarch.com 2002-2005 / Author: Mihai Bazon\n" + // don't translate this this ;-)
"For latest version visit: http://www.dynarch.com/projects/calendar/\n" +
"Distributed under GNU LGPL.  See http://gnu.org/licenses/lgpl.html for details." +
"\n\n" +
"日期选择操作方式:\n" +
"- 点击或左键按住 \xab, \xbb 选择年份\n" +
"- 点击或左键按住 " + String.fromCharCode(0x2039) + ", " + String.fromCharCode(0x203a) + " 选择月份\n";
Calendar._TT["ABOUT_TIME"] = "\n\n" +
"时间选择操作:\n" +
"- 左键点击时间区域里的小时或分钟,即可自动递增1\n" +
"- 同时按下Shift键和用左键点击时间区域里的小时或分钟,即可自动递减\n" +
"- 用左键在要修改的时间区域里拖着向左或向右即可";

Calendar._TT["PREV_YEAR"] = "点击转到上一个年份";
Calendar._TT["PREV_MONTH"] = "点击转到上一个月份";
Calendar._TT["GO_TODAY"] = "选择今天日期";
Calendar._TT["NEXT_MONTH"] = "点击转到上一个月份";
Calendar._TT["NEXT_YEAR"] = "点击转到上一个年份";
Calendar._TT["SEL_DATE"] = "请选择日期";
Calendar._TT["DRAG_TO_MOVE"] = "可进行拖拉操作移动当前日期窗口";
Calendar._TT["PART_TODAY"] = " (今天)";

// the following is to inform that "%s" is to be the first day of week
// %s will be replaced with the day name.
Calendar._TT["DAY_FIRST"] = "设置%s为每个星期的第一天";

// This may be locale-dependent.  It specifies the week-end days, as an array
// of comma-separated numbers.  The numbers are from 0 to 6: 0 means Sunday, 1
// means Monday, etc.
Calendar._TT["WEEKEND"] = "0,6";

Calendar._TT["CLOSE"] = "关闭";
Calendar._TT["TODAY"] = "今天";
Calendar._TT["TIME_PART"] = "点击/拖拉修改时间值";

// date formats
Calendar._TT["DEF_DATE_FORMAT"] = "%Y-%m-%d";
Calendar._TT["TT_DATE_FORMAT"] = "%a, %b %e";

Calendar._TT["WK"] = "周";
Calendar._TT["TIME"] = "时间:";