import 'dart:math';

import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../logic/utils/constants.dart';
import '../../../../styles/colours.dart';

class BarChartCard extends ConsumerStatefulWidget {
  final String? chartTitle;

  final Color barColor = Colors.teal;

  final Color barBackgroundColor = Colors.tealAccent;

  final Color touchedBarColor = Colors.white;

  const BarChartCard({super.key, required this.chartTitle});

  @override
  ConsumerState<BarChartCard> createState() => _BarChartCardState();
}

class _BarChartCardState extends ConsumerState<BarChartCard> {

  final Duration animDuration = const Duration(milliseconds: 250);

  int chartIndex = 0;

  bool isChartAnimating = false;

  @override
  Widget build(BuildContext context) {
    return Stack(children: [parentCard(context), childCard()]);
  }

  Widget parentCard(BuildContext context) {
    return Positioned.fill(child: Card(elevation: 3.0, color: cardColour));
  }

  Widget childCard() {
    return Padding(
      padding: const EdgeInsets.all(cardPadding),
      child: Column(
        children: [
          Text(
            widget.chartTitle!,
            style: GoogleFonts.montserrat(
              color: primaryTextColour,
              fontSize: 20,
              fontWeight: FontWeight.bold,
            ),
          ),
          Expanded(child: BarChart(isChartAnimating ? randomData() : mainBarData()))
        ],
      ),
    );
  }

  GlobalKey _getGlobalKey() {
    return GlobalKey();
  }

  BarChartData mainBarData() {
    return BarChartData(
      barTouchData: BarTouchData(
        enabled: true,
        touchTooltipData: BarTouchTooltipData(
          getTooltipColor: (_) => Colors.teal,
          tooltipHorizontalAlignment: FLHorizontalAlignment.left,
          tooltipMargin: 10,
          getTooltipItem: (group, groupIndex, rod, rodIndex) {
            String weekDay = switch (group.x) {
              0 => 'Monday',
              1 => 'Tuesday',
              2 => 'Wednesday',
              3 => 'Thursday',
              4 => 'Friday',
              5 => 'Saturday',
              6 => 'Sunday',
              _ => throw Error(),
            };
            return BarTooltipItem(
              '$weekDay\n',
              const TextStyle(
                color: Colors.white,
                fontWeight: FontWeight.bold,
                fontSize: 18,
              ),
              children: <TextSpan>[
                TextSpan(
                  text: ((rod.toY - 1).toStringAsFixed(1)).toString(),
                  style: const TextStyle(
                    color: Colors.white,
                    fontSize: 16,
                    fontWeight: FontWeight.w500,
                  ),
                ),
              ],
            );
          },
        ),
        touchCallback: (FlTouchEvent event, barTouchResponse) {
          setState(() {
            if (!event.isInterestedForInteractions ||
                barTouchResponse == null ||
                barTouchResponse.spot == null) {
              chartIndex = -1;
              return;
            }
            chartIndex = barTouchResponse.spot!.touchedBarGroupIndex;
          });
        },
      ),
      titlesData: FlTitlesData(
        show: true,
        rightTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        topTitles: const AxisTitles(
          sideTitles: SideTitles(showTitles: false),
        ),
        bottomTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            getTitlesWidget: getTitles,
            reservedSize: 38,
          ),
        ),
        leftTitles: const AxisTitles(
          sideTitles: SideTitles(
            showTitles: false,
          ),
        ),
      ),
      borderData: FlBorderData(
        show: false,
      ),
      barGroups: showingGroups(),
      gridData: const FlGridData(show: false),
    );
  }

  BarChartData randomData() {
    return BarChartData(
      barTouchData: const BarTouchData(
        enabled: false,
      ),
      titlesData: FlTitlesData(
        show: true,
        bottomTitles: AxisTitles(
          sideTitles: SideTitles(
            showTitles: true,
            getTitlesWidget: getTitles,
            reservedSize: 38,
          ),
        ),
        leftTitles: const AxisTitles(
          sideTitles: SideTitles(
            showTitles: false,
          ),
        ),
        topTitles: const AxisTitles(
          sideTitles: SideTitles(
            showTitles: false,
          ),
        ),
        rightTitles: const AxisTitles(
          sideTitles: SideTitles(
            showTitles: false,
          ),
        ),
      ),
      borderData: FlBorderData(
        show: false,
      ),
      barGroups: List.generate(
        7,
            (i) => makeGroupData(
          i,
          Random().nextInt(15).toDouble() + 6,
          barColor: Colors.red,
        ),
      ),
      gridData: const FlGridData(show: false),
    );
  }

  BarChartGroupData makeGroupData(
      int x,
      double y, {
        bool isTouched = false,
        Color? barColor,
        double width = 22,
        List<int> showTooltips = const [],
      }) {
    barColor ??= widget.barColor;
    return BarChartGroupData(
      x: x,
      barRods: [
        BarChartRodData(
          toY: isTouched ? y + 1 : y,
          color: isTouched ? widget.touchedBarColor : barColor,
          width: width,
          borderSide: isTouched
              ? BorderSide(color: widget.touchedBarColor.withAlpha(100))
              : const BorderSide(color: Colors.white, width: 0),
          backDrawRodData: BackgroundBarChartRodData(
            show: true,
            toY: 20,
            color: widget.barBackgroundColor,
          ),
        ),
      ],
      showingTooltipIndicators: showTooltips,
    );
  }

  List<BarChartGroupData> showingGroups() => List.generate(
      7,
          (i) => switch (i) {
        0 => makeGroupData(0, 5, isTouched: i == chartIndex),
        1 => makeGroupData(1, 6, isTouched: i == chartIndex),
        2 => makeGroupData(2, 5, isTouched: i == chartIndex),
        3 => makeGroupData(3, 7, isTouched: i == chartIndex),
        4 => makeGroupData(4, 9, isTouched: i == chartIndex),
        5 => makeGroupData(5, 11, isTouched: i == chartIndex),
        6 => makeGroupData(6, 6, isTouched: i == chartIndex),
        _ => throw Error(),
      }
  );

  Widget getTitles(double value, TitleMeta meta) {
    const style = TextStyle(
      color: primaryTextColour,
      fontWeight: FontWeight.bold,
      fontSize: 14,
    );
    String text = switch (value.toInt()) {
      0 => 'M',
      1 => 'T',
      2 => 'W',
      3 => 'T',
      4 => 'F',
      5 => 'S',
      6 => 'S',
      _ => '',
    };
    return SideTitleWidget(
      meta: meta,
      space: 16,
      child: Text(text, style: style),
    );
  }

}
