import 'package:gap/gap.dart';

import '../../../logic/utils/constants.dart';
import '../../common/buttons/primary_button.dart';
import '../../common/cards/chart_cards/bar_chart_card.dart';
import '../../common/cards/chart_cards/pie_chart_card.dart';
import '../../common/cards/chart_cards/stat_card.dart';
import '../../common/cards/content_card.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../styles/colours.dart';
import '../../common/cards/monthly_calendar_card.dart';
import '../../state/dashboard_event.dart';
import '../../state/dashboard_state.dart';

class DashboardScreen extends ConsumerStatefulWidget with DashboardState, DashboardEvent {
  const DashboardScreen({super.key});

  @override
  ConsumerState<DashboardScreen> createState() => _DashboardScreenState();
}

class _DashboardScreenState extends ConsumerState<DashboardScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(screenGridPadding),
      child: CustomScrollView(
        shrinkWrap: true,
        slivers: <Widget>[
          SliverToBoxAdapter(
            child: ContentCard(
              child: Text(
                "Good Afternoon Dr. Strange",
                style: GoogleFonts.montserrat(
                  fontSize: 25,
                  fontWeight: FontWeight.bold,
                  color: primaryTextColour,
                ),
              ),
            ),
          ),
          SliverGap(5),
          SliverToBoxAdapter(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                PrimaryButton(buttonText: "Export", buttonIcon: Icon(Icons.download_rounded, size: 15.0)),
                Gap(5),
                PrimaryButton(buttonText: "Print", buttonIcon: Icon(Icons.print_rounded, size: 15.0)),
              ],
            ),),
          SliverGap(5),
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
              PieChartCard(chartTitle: "Patient Demographics"),
              BarChartCard(chartTitle: "Daily Appointments"),
              StatCard(
                statIcon: Icons.group_rounded,
                statTitle: "Weekly Patients",
                statNumber: DashboardState().statWeeklyPatients(ref),
              ),
              StatCard(
                statIcon: Icons.group_rounded,
                statTitle: "Weekly Referrals",
                statNumber: DashboardState().statWeeklyReferrals(ref),
              ),
              MonthlyCalendarCard(),
            ]),
          ),
        ],
      ),
    );
  }
}

