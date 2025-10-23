import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../logic/utils/constants.dart';
import '../../../../styles/colours.dart';

class PieChartCard extends ConsumerStatefulWidget {
  final String? chartTitle;

  const PieChartCard({super.key, required this.chartTitle});

  @override
  ConsumerState<PieChartCard> createState() => _PieChartCardState();
}

class _PieChartCardState extends ConsumerState<PieChartCard> {
  int chartIndex = 0;

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
              color: blackTextColour,
              fontSize: 20,
              fontWeight: FontWeight.bold,
            ),
          ),
          Expanded(
            child: PieChart(
              PieChartData(
                pieTouchData: PieTouchData(
                  enabled: true,
                  touchCallback: (FlTouchEvent touchEvent, pieTouchResponse) {
                    setState(() {
                      if (!touchEvent.isInterestedForInteractions ||
                          pieTouchResponse == null ||
                          pieTouchResponse.touchedSection == null) {
                        chartIndex = -1;
                        return;
                      }
                      chartIndex =
                          pieTouchResponse.touchedSection!.touchedSectionIndex;
                    });
                  },
                  mouseCursorResolver: (FlTouchEvent clickEvent, pieClickResponse) {
                    setState((){
                      if (!clickEvent.isInterestedForInteractions ||
                          pieClickResponse == null ||
                          pieClickResponse.touchedSection == null) {
                        chartIndex = -1;
                        return;
                      }
                      chartIndex =
                          pieClickResponse.touchedSection!.touchedSectionIndex;
                    });
                    return SystemMouseCursors.click;
                  },
                ),
                borderData: FlBorderData(show: false),
                sectionsSpace: 0,
                centerSpaceRadius: 10,
                sections: paintSectionData(),
              ),
            ),
          ),
        ],
      ),
    );
  }

  GlobalKey _getGlobalKey() {
    return GlobalKey();
  }

  List<PieChartSectionData>? paintSectionData() {
    return List.generate(4, (i) {
      final isTouched = i == chartIndex;
      final fontSize = isTouched ? 20.0 : 16.0;
      final radius = isTouched ? 110.0 : 100.0;
      final widgetSize = isTouched ? 55.0 : 40.0;
      const shadows = [Shadow(color: Colors.black, blurRadius: 2)];

      return switch (i) {
        0 => PieChartSectionData(
          color: Colors.red,
          value: 40,
          title: '40%',
          radius: radius,
          titleStyle: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.bold,
            color: const Color(0xffffffff),
            shadows: shadows,
          ),
        ),
        1 => PieChartSectionData(
          color: Colors.yellow,
          value: 30,
          title: '30%',
          radius: radius,
          titleStyle: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.bold,
            color: const Color(0xffffffff),
            shadows: shadows,
          ),
        ),
        2 => PieChartSectionData(
          color: Colors.purple,
          value: 16,
          title: '16%',
          radius: radius,
          titleStyle: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.bold,
            color: const Color(0xffffffff),
            shadows: shadows,
          ),
        ),
        3 => PieChartSectionData(
          color: Colors.green,
          value: 15,
          title: '15%',
          radius: radius,
          titleStyle: TextStyle(
            fontSize: fontSize,
            fontWeight: FontWeight.bold,
            color: const Color(0xffffffff),
            shadows: shadows,
          ),
        ),
        _ => throw StateError('Invalid state data'),
      };
    });
  }
}
