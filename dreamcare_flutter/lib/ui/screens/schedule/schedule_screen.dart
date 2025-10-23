import 'dart:math' as Math;

import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../logic/state/common/common_ui_providers.dart';
import '../../../logic/utils/constants.dart';
import '../../../styles/colours.dart';
import '../../common/cards/patient_table_card.dart';
import '../../common/cards/content_card.dart';
import '../../common/cards/chart_cards/stat_card.dart';
import '../../common/cards/monthly_calendar_card.dart';

class ScheduleScreen extends ConsumerStatefulWidget {
  const ScheduleScreen({super.key});

  @override
  ConsumerState<ScheduleScreen> createState() => _ScheduleScreenState();
}

class _ScheduleScreenState extends ConsumerState<ScheduleScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(screenGridPadding),
      child: CustomScrollView(
        slivers: <Widget>[
          SliverToBoxAdapter(
            child: ContentCard(
              child: Text(
                "Appointments",
                style: GoogleFonts.montserrat(
                  fontSize: 25,
                  fontWeight: FontWeight.bold,
                  color: blackTextColour,
                ),
              ),
            ),
          ),
          paintHeader("Upcoming Appointments"),
          SliverGrid(
            gridDelegate: SliverQuiltedGridDelegate(
              crossAxisCount: 32,
              pattern: [
                QuiltedGridTile(8, 8),
                QuiltedGridTile(8, 8),
                QuiltedGridTile(8, 8),
                QuiltedGridTile(8, 8),
                QuiltedGridTile(16, 16),
                QuiltedGridTile(16, 16),
              ],
            ),
            delegate: SliverChildListDelegate([
              ContentCard(child: Icon(Icons.access_alarm_rounded)),
              ContentCard(child: Icon(Icons.read_more_rounded)),
              StatCard(
                statIcon: Icons.group_rounded,
                statTitle: ref.read(testTextProvider),
                statNumber: 20,
              ),
              ContentCard(child: Icon(Icons.read_more_rounded)),
              MonthlyCalendarCard(),
              PatientTableCard(),
            ]),
          ),
        ],
      ),
    );
  }

  SliverPersistentHeader paintHeader(String headerText) {
    return SliverPersistentHeader(
      pinned: true,
      delegate: _SliverHeaderDelegate(
        minHeight: 50.0,
        maxHeight: 75.0,
        child: Card(
          color: Colors.tealAccent,
          child: Center(
            child: Text(
              headerText,
              textAlign: TextAlign.end,
              style: GoogleFonts.montserrat(
                fontSize: 20,
                fontWeight: FontWeight.bold,
                color: blackTextColour,
              ),
            ),
          ),
        ),
      ),
    );
  }
}

class _SliverHeaderDelegate extends SliverPersistentHeaderDelegate {
  _SliverHeaderDelegate({
    required this.minHeight,
    required this.maxHeight,
    required this.child,
  });
  final double minHeight;
  final double maxHeight;
  final Widget child;
  @override
  double get minExtent => minHeight;
  @override
  double get maxExtent => Math.max(maxHeight, minHeight);
  @override
  Widget build(
    BuildContext context,
    double shrinkOffset,
    bool overlapsContent,
  ) {
    return SizedBox.expand(child: child);
  }

  @override
  bool shouldRebuild(_SliverHeaderDelegate oldDelegate) {
    return maxHeight != oldDelegate.maxHeight ||
        minHeight != oldDelegate.minHeight ||
        child != oldDelegate.child;
  }
}
